using CreditCarbonAPI.Models;
using CreditCarbonAPI.Repositories.interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace CreditCarbonAPI.Repositories
{
    public class ProjectCarbonMarketsRepository : IProjectCarbonMarketsRepository
    {
        private ICarbonCreditEfRepository<ProjectCarbonMarket> _carbonCreditEfRepository;

        public ProjectCarbonMarketsRepository(ICarbonCreditEfRepository<ProjectCarbonMarket> carbonCreditEfRepository){
            _carbonCreditEfRepository = carbonCreditEfRepository;
        }

        public IEnumerable<ProjectCarbonMarket> Gets()
        {
            try
            {
                var listProjectCarbonMarket = _carbonCreditEfRepository.Gets();
                return listProjectCarbonMarket;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

    }
}