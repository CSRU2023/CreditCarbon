using CreditCarbonAPI.Models;

namespace CreditCarbonAPI.Repositories.interfaces
{
    public interface IProjectCarbonRepository{
        IEnumerable<ProjectCarbon> Gets();
        IEnumerable<TechnologyType> GetTechnologyTypeCombobox();
        ProjectCarbonById GetProjectCarbonById(int id);
        ProjectCarbonById Insert(ProjectCarbonById entitiy);
    }
}