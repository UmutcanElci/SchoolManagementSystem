using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Backend.Migrations;

public partial class Parent
{
    [Key]
    public int Id { get; set; }

    [StringLength(70)]
    public string FatherName { get; set; } = null!;

    [StringLength(70)]
    public string MotherName { get; set; } = null!;

    [StringLength(50)]
    public string Surname { get; set; } = null!;

    [StringLength(11)]
    public string? PhoneNumber { get; set; }

    [StringLength(100)]
    public string Email { get; set; } = null!;

    public int? PasswordId { get; set; }

    [StringLength(1000)]
    public string Address { get; set; } = null!;

    public int IdentityId { get; set; }

    [InverseProperty("Parent")]
    public virtual ICollection<ParentsAndStudent> ParentsAndStudents { get; set; } = new List<ParentsAndStudent>();

    [ForeignKey("PasswordId")]
    [InverseProperty("Parents")]
    public virtual Password? Password { get; set; }

    [InverseProperty("Parent")]
    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    [InverseProperty("Parent")]
    public virtual ICollection<Wallet> Wallets { get; set; } = new List<Wallet>();
}
