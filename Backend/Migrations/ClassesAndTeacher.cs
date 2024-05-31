using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Backend.Migrations;

public partial class ClassesAndTeacher
{
    [Key]
    public int Id { get; set; }

    public int ClassId { get; set; }

    public int TeacherId { get; set; }
}
