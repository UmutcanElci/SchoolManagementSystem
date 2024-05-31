using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Backend.Migrations;

public partial class Student
{
    [Key]
    public int Id { get; set; }

    [StringLength(70)]
    public string Name { get; set; } = null!;

    [StringLength(50)]
    public string Surname { get; set; } = null!;

    [StringLength(11)]
    public string? StudentNumber { get; set; }

    public int? PasswordId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime DateOfBirth { get; set; }

    [StringLength(1000)]
    public string Address { get; set; } = null!;

    [StringLength(100)]
    public string Email { get; set; } = null!;

    public bool Gender { get; set; }

    public int? DistrictId { get; set; }

    public int? ClassId { get; set; }

    public int? ParentId { get; set; }

    public int? Grade { get; set; }

    [StringLength(10)]
    public string? Age { get; set; }

    [ForeignKey("ClassId")]
    [InverseProperty("Students")]
    public virtual Class? Class { get; set; }

    [ForeignKey("DistrictId")]
    [InverseProperty("Students")]
    public virtual District? District { get; set; }

    [ForeignKey("ParentId")]
    [InverseProperty("Students")]
    public virtual Parent? Parent { get; set; }

    [InverseProperty("Student")]
    public virtual ICollection<ParentsAndStudent> ParentsAndStudents { get; set; } = new List<ParentsAndStudent>();

    [ForeignKey("PasswordId")]
    [InverseProperty("Students")]
    public virtual Password? Password { get; set; }

    [InverseProperty("Student")]
    public virtual ICollection<StudentInformation> StudentInformations { get; set; } = new List<StudentInformation>();

    [InverseProperty("Student")]
    public virtual ICollection<Wallet> Wallets { get; set; } = new List<Wallet>();
}
