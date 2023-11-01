using CreditCarbonAPI.Models;

namespace CreditCarbonAPI.Repositories.interfaces
{
    public interface IUserRepository{
        IEnumerable<User> Gets();
        User GetUserById(int Id);
        public bool SaveUser(User model);
    }
}