using CreditCarbonAPI.Models;
using CreditCarbonAPI.Repositories.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net;

namespace CreditCarbonAPI.Repositories
{
    public class ProjectCarbonRepository : IProjectCarbonRepository
    {
        private ICarbonCreditEfRepository<ProjectCarbon> _projectCarbon;
        private ICarbonCreditEfRepository<TechnologyType> _technologyType;
        private ICarbonCreditEfRepository<User> _user;
        private ICarbonCreditEfRepository<ProjectCarbonDeveloper> _projectCarconDeveloper;

        public ProjectCarbonRepository(ICarbonCreditEfRepository<ProjectCarbon> projectCarbon
        ,ICarbonCreditEfRepository<TechnologyType> technologyType,
        ICarbonCreditEfRepository<User> user,
        ICarbonCreditEfRepository<ProjectCarbonDeveloper> projectCarconDeveloper)
        {
            _projectCarbon = projectCarbon;
            _technologyType = technologyType;
            _user = user;
            _projectCarconDeveloper = projectCarconDeveloper;
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

        public ProjectCarbonById GetProjectCarbonById(int id)
        {
            try
            {
                var projectCarbons = _projectCarbon.Gets();
                var technologyTypes = _technologyType.Gets();
                var projectDeveloper = _projectCarconDeveloper.Gets();

                var data = (from a in projectCarbons
                               join c in technologyTypes on a.TechnologyTypeId equals c.TechnologyTypeId
                               join d in projectDeveloper on a.ProjectCarbonId equals d.ProjectCarbonId into g
                            from developer in g.DefaultIfEmpty()
                            where a.ProjectCarbonId == id
                               select new ProjectCarbonById
                               {
                                  ProjectCarbonId = a.ProjectCarbonId,
                                  TechnologyTypeId = a.TechnologyTypeId,
                                  TechnologyTypeName = c.TechnologyTypeName,
                                  UserId = a.UserId,
                                  ProjectName = a.ProjectName,
                                  ProjectDescription = a.ProjectDescription,
                                  Location = a.Location,
                                  LocationCoordinates = a.LocationCoordinates,
                                  Investment = a.Investment,
                                  AmountGreenhouseGases = a.AmountGreenhouseGases,
                                  StartDate = a.StartDate,
                                  EndDate = a.EndDate,
                                  ProjectOwner = a.ProjectOwner,
                                  Coordinator = a.Coordinator,
                                  Position = a.Position,
                                  Address = a.Address,
                                  Tel = a.Tel,
                                  Email = a.Email,
                                  CreatedDate = a.CreatedDate,
                                  CreatedByUserId = a.CreatedByUserId,
                                  UpdatedDate = a.UpdatedDate,
                                  UpdatedByUserId = a.UpdatedByUserId,
                                  ProjectCarbonDevelopers = developer != null ? new List<ProjectCarbonDeveloper>() { developer } : new List<ProjectCarbonDeveloper>() 
                               }).FirstOrDefault();

                return data ?? new ProjectCarbonById();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}