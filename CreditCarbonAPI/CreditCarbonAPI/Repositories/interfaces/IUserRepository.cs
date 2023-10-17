using CreditCarbonAPI.Models;

namespace CreditCarbonAPI.Repositories.interfaces
{
    public interface IUserRepository{
        IEnumerable<User> Gets();
    }
}