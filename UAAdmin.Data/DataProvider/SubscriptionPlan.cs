using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UAAdmin;

public partial class SubscriptionPlan
{
    [Key]
    [Column("PlanID")]
    public int PlanId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? PlanName { get; set; }

    [Unicode(false)]
    public string? Description { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? Price { get; set; }

    public int? ValidityPeriodInMonths { get; set; }

    [Unicode(false)]
    public string? Features { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? SupportLevel { get; set; }

    public bool? IsActive { get; set; }

    [InverseProperty("SubscriptionPlan")]
    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
}
