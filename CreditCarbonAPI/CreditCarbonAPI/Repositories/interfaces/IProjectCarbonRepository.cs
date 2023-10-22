using CreditCarbonAPI.Models;

namespace CreditCarbonAPI.Repositories.interfaces
{
    public interface IProjectCarbonRepository{
        IEnumerable<ProjectCarbon> Gets();
        IEnumerable<TechnologyType> GetTechnologyTypeCombobox();
    }
}