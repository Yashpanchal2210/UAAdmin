using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UAAdmin;

[Table("SuperAdmin")]
[Index("Username", Name = "UQ__SuperAdm__536C85E4612412E6", IsUnique = true)]
public partial class SuperAdmin
{
    [Key]
    [Column("AdminID")]
    public int AdminId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Username { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Password { get; set; }
}
