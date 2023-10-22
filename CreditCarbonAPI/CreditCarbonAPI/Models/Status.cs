using System;
using System.Collections.Generic;

namespace CreditCarbonAPI.Models;

public partial class Status
{
    public int StatusId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public int? OrderRank { get; set; }

    public virtual ICollection<ProjectCarbonStatus> ProjectCarbonStatuses { get; set; } = new List<ProjectCarbonStatus>();
}
