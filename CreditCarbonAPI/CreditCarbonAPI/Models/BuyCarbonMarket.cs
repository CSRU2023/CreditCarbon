﻿using System;
using System.Collections.Generic;

namespace CreditCarbonAPI.Models;

public partial class BuyCarbonMarket
{
    public int ProjectCarbonMarketsId { get; set; }

    public int ProjectCarbonId { get; set; }

    public int? AmountGreenhouseGases { get; set; }

    public int? Price { get; set; }

    public int? UnitPrice { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedByUserId { get; set; }

    public DateTime UpdatedDate { get; set; }

    public int UpdatedByUserId { get; set; }

    public int BuyForUserId { get; set; }
    public int BuyAmountGreenhouseGases { get; set; }
}
