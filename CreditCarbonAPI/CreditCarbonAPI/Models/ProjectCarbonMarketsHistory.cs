using System;
using System.Collections.Generic;

namespace CreditCarbonAPI.Models;

public partial class ProjectCarbonMarketsHistory
{
    public int HistoryId { get; set; }

    public int ProjectCarbonMarketsId { get; set; }

    public int ProjectCarbonId { get; set; }

    public int? AmountGreenhouseGasesBuy { get; set; }

    public int? AmountGreenhouseGasesRemaining { get; set; }

    public int? Price { get; set; }

    public int? UnitPrice { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedByUserId { get; set; }

    public virtual ProjectCarbon ProjectCarbon { get; set; }

    public virtual ProjectCarbonMarket ProjectCarbonMarkets { get; set; }
}
