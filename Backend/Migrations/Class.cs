using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Backend.Migrations;

[Table("Class")]
public partial class Class
{
    [Key]
    public int Id { get; set; }

    public int Grade { get; set; }

    [Column("Class_Letter")]
    [StringLength(10)]
    [Unicode(false)]
    public string ClassLetter { get; set; } = null!;

    [InverseProperty("Class")]
    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
