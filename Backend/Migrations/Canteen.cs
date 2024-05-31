using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Backend.Migrations;

[Keyless]
[Table("Canteen")]
public partial class Canteen
{
    [StringLength(50)]
    public string? Foods { get; set; }

    public double Price { get; set; }

    [StringLength(50)]
    public string? PurchaseHistory { get; set; }

    public int? StudentId { get; set; }

    public int? WalletId { get; set; }

    [ForeignKey("StudentId")]
    public virtual Student? Student { get; set; }

    [ForeignKey("WalletId")]
    public virtual Wallet? Wallet { get; set; }
}
