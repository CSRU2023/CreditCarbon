using System;
using System.Collections.Generic;

namespace CreditCarbonAPI.Models;

public partial class ProjectCarbonStatus
{
    public int ProjectCarbonStatusId { get; set; }

    public int ProjectCarbonId { get; set; }

    public int StatusId { get; set; }

    public string Massage { get; set; }

    public bool? IsApprove { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedByUserId { get; set; }

    public virtual ProjectCarbon ProjectCarbon { get; set; }

    public virtual Status Status { get; set; }
}
