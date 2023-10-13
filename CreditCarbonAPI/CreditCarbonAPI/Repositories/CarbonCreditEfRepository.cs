using CreditCarbonAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CreditCarbonAPI.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class CarbonCreditEfRepository<TEntity> where TEntity : class
    {
        internal CarbonCreditContext context;
        internal DbSet<TEntity> dbSet;
        public CarbonCreditEfRepository(CarbonCreditContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public IEnumerable<ProjectCarbon> GetProjectCarbon()
        {
            return context.ProjectCarbons.ToList();
        }
    }
}