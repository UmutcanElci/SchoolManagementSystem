using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Backend.Migrations;

[Table("Wallet")]
public partial class Wallet
{
    [Key]
    public int Id { get; set; }

    public double? Balance { get; set; }

    public int StudentId { get; set; }

    public int ParentId { get; set; }

    [ForeignKey("ParentId")]
    [InverseProperty("Wallets")]
    public virtual Parent Parent { get; set; } = null!;

    [ForeignKey("StudentId")]
    [InverseProperty("Wallets")]
    public virtual Student Student { get; set; } = null!;
}
