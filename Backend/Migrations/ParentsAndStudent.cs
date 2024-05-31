using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Backend.Migrations;

public partial class ParentsAndStudent
{
    [Key]
    public int FamilyId { get; set; }

    public int ParentId { get; set; }

    public int StudentId { get; set; }

    [ForeignKey("ParentId")]
    [InverseProperty("ParentsAndStudents")]
    public virtual Parent Parent { get; set; } = null!;

    [ForeignKey("StudentId")]
    [InverseProperty("ParentsAndStudents")]
    public virtual Student Student { get; set; } = null!;
}
