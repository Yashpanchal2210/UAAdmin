using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UAAdmin;

public partial class VehicleDetail
{
    [Key]
    [Column("ImageID")]
    public int ImageId { get; set; }

    [Column("ClientID")]
    public int? ClientId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Make { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Model { get; set; }

    public int? Year { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Color { get; set; }

    public int? Mileage { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? TransmissionType { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? FuelType { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    public decimal? EngineSize { get; set; }

    [Column("VIN")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Vin { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? LicensePlateNumber { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Condition { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? Price { get; set; }

    [Unicode(false)]
    public string? Description { get; set; }

    public byte[]? ImageData { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UploadedDate { get; set; }

    [ForeignKey("ClientId")]
    [InverseProperty("VehicleDetails")]
    public virtual Client? Client { get; set; }
}
