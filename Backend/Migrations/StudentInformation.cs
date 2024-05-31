using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Backend.Migrations;

[Table("StudentInformation")]
public partial class StudentInformation
{
    [Key]
    public int Id { get; set; }

    public int StudentId { get; set; }

    public int? GradeId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime EntryTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ExitTime { get; set; }

    public bool AttendaceStatus { get; set; }

    [ForeignKey("StudentId")]
    [InverseProperty("StudentInformations")]
    public virtual Student Student { get; set; } = null!;
}
