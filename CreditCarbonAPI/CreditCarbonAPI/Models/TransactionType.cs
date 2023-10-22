using System;
using System.Collections.Generic;

namespace CreditCarbonAPI.Models;

public partial class TransactionType
{
    public int TransactionTypeId { get; set; }

    public string TransactionTypeCode { get; set; }

    public string TransactionTypeName { get; set; }

    public string Description { get; set; }

    public virtual ICollection<ProjectCarbonTransaction> ProjectCarbonTransactions { get; set; } = new List<ProjectCarbonTransaction>();
}
