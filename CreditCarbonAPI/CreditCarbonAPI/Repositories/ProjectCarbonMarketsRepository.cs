using CreditCarbonAPI.Models;
using CreditCarbonAPI.Repositories.interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace CreditCarbonAPI.Repositories
{
    public class ProjectCarbonMarketsRepository : IProjectCarbonMarketsRepository
    {
        private ICarbonCreditEfRepository<ProjectCarbonMarket> _carbonCreditEfRepository;
        private ICarbonCreditEfRepository<ProjectCarbon> _projectCarbon;

        public ProjectCarbonMarketsRepository(ICarbonCreditEfRepository<ProjectCarbonMarket> carbonCreditEfRepository, 
                                                ICarbonCreditEfRepository<ProjectCarbon> projectCarbon)
        {
            _carbonCreditEfRepository = carbonCreditEfRepository;
            _projectCarbon = projectCarbon;
        }

        public IEnumerable<ProjectCarbonMarket> Gets()
        {
            try
            {
                var p = _projectCarbon.Gets();

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