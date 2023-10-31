using CreditCarbonAPI.Models;

namespace CreditCarbonAPI.Repositories.interfaces
{
    public interface IUserRepository{
        User GetUserById(int Id);
        public bool SaveUser(User model);
    }
}