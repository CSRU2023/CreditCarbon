using System;
using System.Collections.Generic;

namespace CreditCarbonAPI.Models;

public partial class User
{
    public int UserId { get; set; }

    public int RoleId { get; set; }

    public string UserName { get; set; }

    public string Password { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string Tel { get; set; }

    public string Address { get; set; }

    public string Business { get; set; }

    public decimal? Wallet { get; set; }

    public decimal? WalletCarbon { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedByUserId { get; set; }

    public DateTime UpdatedDate { get; set; }

    public int UpdatedByUserId { get; set; }

    public virtual ICollection<ProjectCarbon> ProjectCarbons { get; set; } = new List<ProjectCarbon>();

    public virtual Role Role { get; set; }
}
