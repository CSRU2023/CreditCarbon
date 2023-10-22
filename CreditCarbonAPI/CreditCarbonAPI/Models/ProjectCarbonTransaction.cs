using System;
using System.Collections.Generic;

namespace CreditCarbonAPI.Models;

public partial class ProjectCarbonTransaction
{
    public int ProjectCarbonTransactionId { get; set; }

    public int TransactionTypeId { get; set; }

    public int ProjectCarbonId { get; set; }

    public int UserId { get; set; }

    public int AmountGreenhouseGases { get; set; }

    public decimal? Price { get; set; }

    public string Massage { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedByUserId { get; set; }

    public virtual ProjectCarbon ProjectCarbon { get; set; }

    public virtual TransactionType TransactionType { get; set; }
}
