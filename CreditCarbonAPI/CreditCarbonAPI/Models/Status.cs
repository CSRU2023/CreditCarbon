using System;
using System.Collections.Generic;

namespace CreditCarbonAPI.Models;

public partial class Status
{
    public int StatusId { get; set; }

    public string StatusText { get; set; }

    public virtual ICollection<ProjectCarbon> ProjectCarbons { get; set; } = new List<ProjectCarbon>();
}
