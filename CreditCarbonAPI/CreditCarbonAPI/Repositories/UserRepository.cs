using CreditCarbonAPI.Models;
using CreditCarbonAPI.Repositories.interfaces;
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

        public IEnumerable<User> Gets()
        {
            try
            {
                var listUser = _carbonCreditEfRepository.Gets();
                return listUser;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

    }
}