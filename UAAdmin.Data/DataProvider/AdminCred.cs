using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UAAdmin;

[Table("AdminCred")]
public partial class AdminCred
{
    [Key]
    public int Id { get; set; }

    [StringLength(255)]
    public string UserName { get; set; } = null!;

    [StringLength(255)]
    public string Password { get; set; } = null!;
}
