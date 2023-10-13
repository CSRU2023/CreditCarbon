using System;
using System.Collections.Generic;

namespace CreditCarbonAPI.Models;

public partial class TechnologyType
{
    public int TechnologyTypeId { get; set; }

    public string TechnologyTypeCode { get; set; }

    public string TechnologyTypeName { get; set; }

    public string Description { get; set; }

    public virtual ICollection<ProjectCarbon> ProjectCarbons { get; set; } = new List<ProjectCarbon>();
}
