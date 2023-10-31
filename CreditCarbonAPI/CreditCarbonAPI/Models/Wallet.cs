using System;
using System.Collections.Generic;

namespace CreditCarbonAPI.Models;

public partial class Wallet
{
    public int WalletId { get; set; }

    public int UserId { get; set; }

    public decimal? WalletMoney { get; set; }

    public decimal? WalletCarbon { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedByUserId { get; set; }

    public DateTime UpdatedDate { get; set; }

    public int UpdatedByUserId { get; set; }

    public virtual User User { get; set; }

    public virtual ICollection<WalletTransaction> WalletTransactions { get; set; } = new List<WalletTransaction>();
}
