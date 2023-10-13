using System;
using System.Collections.Generic;

namespace CreditCarbonAPI.Models;

public partial class ProjectCarbon
{
    public int ProjectCarbonId { get; set; }

    public int TechnologyTypeId { get; set; }

    public int UserId { get; set; }

    public int StatusId { get; set; }

    public string ProjectName { get; set; }

    public string ProjectDescription { get; set; }

    public string Location { get; set; }

    public string LocationCoordinates { get; set; }

    public int? Investment { get; set; }

    public int? AmountGreenhouseGases { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string Developer { get; set; }

    public string Coordinator { get; set; }

    public string Position { get; set; }

    public string Address { get; set; }

    public string Tel { get; set; }

    public string Email { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedByUserId { get; set; }

    public DateTime UpdatedDate { get; set; }

    public int UpdatedByUserId { get; set; }

    public virtual ICollection<CarbonMarket> CarbonMarkets { get; set; } = new List<CarbonMarket>();

    public virtual Status Status { get; set; }

    public virtual TechnologyType TechnologyType { get; set; }

    public virtual User User { get; set; }
}
