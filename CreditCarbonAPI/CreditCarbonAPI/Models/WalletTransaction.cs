using System;
using System.Collections.Generic;

namespace CreditCarbonAPI.Models;

public partial class WalletTransaction
{
    public int WalletTransactionId { get; set; }

    public int WalletId { get; set; }

    public decimal? WalletMoney { get; set; }

    public decimal? WalletCarbon { get; set; }

    public byte[] Image { get; set; }

    public string Massage { get; set; }

    public bool StatusTransaction { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedByUserId { get; set; }

    public DateTime UpdatedDate { get; set; }

    public int UpdatedByUserId { get; set; }
}
