using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Backend.Migrations;

[Table("District")]
public partial class District
{
    [Key]
    public int Id { get; set; }

    [Column("District_Name")]
    [StringLength(150)]
    [Unicode(false)]
    public string DistrictName { get; set; } = null!;

    public int CityId { get; set; }

    [ForeignKey("CityId")]
    [InverseProperty("Districts")]
    public virtual City City { get; set; } = null!;

    [InverseProperty("District")]
    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
