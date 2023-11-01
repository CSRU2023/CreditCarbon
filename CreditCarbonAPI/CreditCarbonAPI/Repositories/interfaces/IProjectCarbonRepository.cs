using CreditCarbonAPI.Models;

namespace CreditCarbonAPI.Repositories.interfaces
{
    public interface IProjectCarbonRepository{
        IEnumerable<ProjectCarbonDto> Gets();
        IEnumerable<TechnologyType> GetTechnologyTypeCombobox();
        ProjectCarbonById GetProjectCarbonById(int id);
        ProjectCarbonById Insert(ProjectCarbonById entitiy);
    }
}