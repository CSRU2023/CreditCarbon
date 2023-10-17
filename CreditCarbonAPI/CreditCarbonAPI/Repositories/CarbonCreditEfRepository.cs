using CreditCarbonAPI.Models;
using CreditCarbonAPI.Repositories.interfaces;
using Microsoft.EntityFrameworkCore;

namespace CreditCarbonAPI.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class CarbonCreditEfRepository<TEntity> : ICarbonCreditEfRepository<TEntity> where TEntity : class
    {
        private readonly CarbonCreditContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public CarbonCreditEfRepository(CarbonCreditContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public IEnumerable<TEntity> Gets()
        {
            return _dbSet.ToList();
        }

        public virtual void Insert(TEntity entitiy)
        {
            _context.Add(entitiy);
            _context.SaveChanges();
        }

        public virtual void Update(TEntity entitiy)
        {
            _context.Update(entitiy); 
            _context.SaveChanges();
        }

    }

}