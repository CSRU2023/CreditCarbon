using CreditCarbonAPI.Models;
using CreditCarbonAPI.Repositories.interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace CreditCarbonAPI.Repositories
{
    public class ProjectCarbonRepository : IProjectCarbonRepository
    {
        private ICarbonCreditEfRepository<ProjectCarbon> _projectCarbon;
        private ICarbonCreditEfRepository<TechnologyType> _technologyType;

        public ProjectCarbonRepository(ICarbonCreditEfRepository<ProjectCarbon> projectCarbon
        ,ICarbonCreditEfRepository<TechnologyType> technologyType)
        {
            _projectCarbon = projectCarbon;
            _technologyType = technologyType;
        }

        public IEnumerable<ProjectCarbon> Gets()
        {
            try
            {
                var p = _projectCarbon.Gets();

                var listProjectCarbon = _projectCarbon.Gets();
                return listProjectCarbon;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public IEnumerable<TechnologyType> GetTechnologyTypeCombobox()
        {
            try
            {
                var list = _technologyType.Gets();

                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

    }
}