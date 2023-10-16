using CreditCarbonAPI.Models;

namespace CreditCarbonAPI.Repositories.interfaces
{
    public interface ICarbonCreditEfRepository<TEntity>{
        IEnumerable<TEntity> Gets();
        void Insert(TEntity entitiy);
        void Update(TEntity entitiy);
    }
}