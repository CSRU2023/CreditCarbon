using System;
using System.Collections.Generic;

namespace CreditCarbonAPI.Models;

public partial class ProjectCarbon
{
    public int ProjectCarbonId { get; set; }

    public int TechnologyTypeId { get; set; }

    public int UserId { get; set; }

    public string ProjectName { get; set; }

    public string ProjectDescription { get; set; }

    public string Location { get; set; }

    public string LocationCoordinates { get; set; }

    public int? Investment { get; set; }

    public int? AmountGreenhouseGases { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string ProjectOwner { get; set; }

    public string Coordinator { get; set; }

    public string Position { get; set; }

    public string Address { get; set; }

    public string Tel { get; set; }

    public string Email { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedByUserId { get; set; }

    public DateTime UpdatedDate { get; set; }

    public int UpdatedByUserId { get; set; }

    public virtual ICollection<ProjectCarbonDeveloper> ProjectCarbonDevelopers { get; set; } = new List<ProjectCarbonDeveloper>();

    public virtual ICollection<ProjectCarbonMarket> ProjectCarbonMarkets { get; set; } = new List<ProjectCarbonMarket>();

    public virtual ICollection<ProjectCarbonMarketsHistory> ProjectCarbonMarketsHistories { get; set; } = new List<ProjectCarbonMarketsHistory>();

    public virtual ICollection<ProjectCarbonStatus> ProjectCarbonStatuses { get; set; } = new List<ProjectCarbonStatus>();

    public virtual ICollection<ProjectCarbonTransaction> ProjectCarbonTransactions { get; set; } = new List<ProjectCarbonTransaction>();

    public virtual TechnologyType TechnologyType { get; set; }

    public virtual User User { get; set; }
}
