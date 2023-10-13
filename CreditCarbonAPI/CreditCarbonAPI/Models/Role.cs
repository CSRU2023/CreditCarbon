using System;
using System.Collections.Generic;

namespace CreditCarbonAPI.Models;

public partial class Role
{
    public int RoleId { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public int OrderRank { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedByUserId { get; set; }

    public DateTime UpdatedDate { get; set; }

    public int UpdatedByUserId { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
