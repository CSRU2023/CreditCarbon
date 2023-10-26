namespace CreditCarbonAPI.Models
{
    public class ProjectCarbonById
    {
        public int ProjectCarbonId { get; set; }
        public int TechnologyTypeId { get; set; }
        public string? TechnologyTypeName { get; set; }
        public int UserId { get; set; }
        public string? ProjectName { get; set; }
        public string? ProjectDescription { get; set; }
        public string? Location { get; set; }
        public string? LocationCoordinates { get; set; }
        public int? Investment { get; set; }
        public int? AmountGreenhouseGases { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? ProjectOwner { get; set; }
        public string? Coordinator { get; set; }
        public string? Position { get; set; }
        public string? Address { get; set; }
        public string? Tel { get; set; }
        public string? Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int UpdatedByUserId { get; set; }
        public virtual ICollection<ProjectCarbonDeveloper> ProjectCarbonDevelopers { get; set; } = new List<ProjectCarbonDeveloper>();

    }
}
