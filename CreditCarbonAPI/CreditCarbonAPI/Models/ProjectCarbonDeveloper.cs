using System;
using System.Collections.Generic;

namespace CreditCarbonAPI.Models;

public partial class ProjectCarbonDeveloper
{
    public int ProjectCarbonDeveloperId { get; set; }

    public int ProjectCarbonId { get; set; }

    public string Developer { get; set; }

    public string Coordinator { get; set; }

    public string Position { get; set; }

    public string Address { get; set; }

    public string Tel { get; set; }

    public string Email { get; set; }

    public virtual ProjectCarbon ProjectCarbon { get; set; }
}
