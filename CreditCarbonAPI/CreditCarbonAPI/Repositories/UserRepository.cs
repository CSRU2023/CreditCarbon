using CreditCarbonAPI.Models;
using CreditCarbonAPI.Repositories.interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System;

namespace CreditCarbonAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ICarbonCreditEfRepository<User> _carbonCreditEfRepository;

        public UserRepository(ICarbonCreditEfRepository<User> carbonCreditEfRepository){
            _carbonCreditEfRepository = carbonCreditEfRepository;
        }

        public User GetUserById(int Id)
        {
            try
            {
                var user = _carbonCreditEfRepository.Gets();
                var data = (from a in user
                            where a.UserId == Id
                            where a.IsActive == true
                            select new User
                            {
                                UserId = a.UserId,
                                RoleId = a.RoleId,
                                UserName = a.UserName,
                                Password = a.Password,
                                FirstName = a.FirstName,
                                LastName = a.LastName,
                                Email = a.Email,
                                Tel = a.Tel,
                                Business = a.Business,
                                Occupation = a.Occupation,
                                Position = a.Position,
                                RegistrationNumber = a.RegistrationNumber,
                                Address = a.Address,
                                TambolKhwaeng = a.TambolKhwaeng,
                                AmphurKhet = a.AmphurKhet,
                                Province = a.Province,
                                ZipCode = a.ZipCode,
                                IsActive = a.IsActive,
                                CreatedByUserId = a.CreatedByUserId,
                                CreatedDate = a.CreatedDate,
                                UpdatedByUserId = a.UpdatedByUserId,
                                UpdatedDate = a.UpdatedDate,

                            }).FirstOrDefault();

                return data ?? new User();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public bool SaveUser(User model)
        {
            try
            {
                var userList = _carbonCreditEfRepository.Gets();
                var checkDuplicate = (from a in userList
                                      where a.UserName.ToUpper() == model.UserName.ToUpper()
                                      select new
                                      {
                                          userName = a.UserName

                                      }).FirstOrDefault();
                if (checkDuplicate == null)
                {
                    model.CreatedDate = DateTime.Now;
                    model.UpdatedDate = DateTime.Now;
                    model.UpdatedByUserId = -1;
                    model.CreatedByUserId = -1;
                    model.IsActive = true;
                    _carbonCreditEfRepository.Insert(model);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}