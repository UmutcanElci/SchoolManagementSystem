using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Backend.Migrations;

[Table("City")]
public partial class City
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string CityName { get; set; } = null!;

    [InverseProperty("City")]
    public virtual ICollection<District> Districts { get; set; } = new List<District>();
}
