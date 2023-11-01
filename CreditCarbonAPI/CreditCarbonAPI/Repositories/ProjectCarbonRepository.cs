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
        private ICarbonCreditEfRepository<ProjectCarbonStatus> _projectCarbonStatus;
        private ICarbonCreditEfRepository<Status> _status;
        private ICarbonCreditEfRepository<TechnologyType> _technologyType;
        private ICarbonCreditEfRepository<User> _user;
        private ICarbonCreditEfRepository<ProjectCarbonDeveloper> _projectCarconDeveloper;

        public ProjectCarbonRepository(ICarbonCreditEfRepository<ProjectCarbon> projectCarbon
        , ICarbonCreditEfRepository<TechnologyType> technologyType
        , ICarbonCreditEfRepository<User> user
        , ICarbonCreditEfRepository<ProjectCarbonDeveloper> projectCarconDeveloper
        , ICarbonCreditEfRepository<ProjectCarbonStatus> projectCarbonStatus
        , ICarbonCreditEfRepository<Status> status)
        {
            _projectCarbon = projectCarbon;
            _technologyType = technologyType;
            _user = user;
            _projectCarconDeveloper = projectCarconDeveloper;
            _projectCarbonStatus = projectCarbonStatus;
            _status = status;
        }

        public IEnumerable<ProjectCarbonDto> Gets()
        {
            try
            {
                var projectCarbon = _projectCarbon.Gets();
                var projectCarbonStatus = _projectCarbonStatus.Gets().OrderByDescending(x => x.CreatedDate);
                var status = _status.Gets();

                var listProjectCarbon = (from a in projectCarbon
                            join c in projectCarbonStatus on a.ProjectCarbonId equals c.ProjectCarbonId 
                            join d in status on c.StatusId equals d.StatusId
                            select new ProjectCarbonDto
                            {
                                ProjectCarbonId = a.ProjectCarbonId,
                                TechnologyTypeId = a.TechnologyTypeId,
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
                                StatusId = d.StatusId,
                                StatusName = d.Name,
                                StatusDescription = d.Description,
                                Massage = c.Massage,
                                IsApprove = c.IsApprove,
                                CreatedDate = a.CreatedDate,
                                CreatedByUserId = a.CreatedByUserId,
                                UpdatedDate = a.UpdatedDate,
                                UpdatedByUserId = a.UpdatedByUserId
                            }).ToList();

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

        public ProjectCarbonById Insert(ProjectCarbonById entitiy)
        {
            try
            {
                var pcs = new ProjectCarbonStatus{
                            StatusId = 1,
                            IsApprove = true,
                            CreatedDate = DateTime.Now,
                            CreatedByUserId = entitiy.CreatedByUserId
                        };
                var pc = new ProjectCarbon
                {
                    TechnologyTypeId = entitiy.TechnologyTypeId,
                    UserId = entitiy.UserId,
                    ProjectName = entitiy.ProjectName,
                    ProjectDescription = entitiy.ProjectDescription,
                    Location = entitiy.Location,
                    LocationCoordinates = entitiy.LocationCoordinates,
                    Investment = entitiy.Investment,
                    AmountGreenhouseGases = entitiy.AmountGreenhouseGases,
                    StartDate = entitiy.StartDate,
                    EndDate = entitiy.EndDate,
                    ProjectOwner = entitiy.ProjectOwner,
                    Coordinator = entitiy.Coordinator,
                    Position = entitiy.Position,
                    Address = entitiy.Address,
                    Tel = entitiy.Tel,
                    Email = entitiy.Email,
                    CreatedDate = DateTime.Now,
                    CreatedByUserId = entitiy.CreatedByUserId,
                    UpdatedDate = DateTime.Now,
                    UpdatedByUserId = entitiy.UpdatedByUserId,
                    ProjectCarbonStatuses = new List<ProjectCarbonStatus>(){pcs},
                    ProjectCarbonDevelopers = entitiy.ProjectCarbonDevelopers.ToList()
                };

                _projectCarbon.Insert(pc);
                return entitiy;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}