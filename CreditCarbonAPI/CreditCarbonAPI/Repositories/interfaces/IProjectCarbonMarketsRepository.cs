using CreditCarbonAPI.Models;

namespace CreditCarbonAPI.Repositories.interfaces
{
    public interface IProjectCarbonMarketsRepository{
        IEnumerable<ProjectCarbonMarket> Gets();
        bool BuyCarbon(BuyCarbonMarket model);
    }
}