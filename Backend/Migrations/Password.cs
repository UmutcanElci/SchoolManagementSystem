using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Backend.Migrations;

[Table("Password")]
public partial class Password
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string? LoginPassword { get; set; }

    [InverseProperty("Password")]
    public virtual ICollection<Parent> Parents { get; set; } = new List<Parent>();

    [InverseProperty("Password")]
    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
