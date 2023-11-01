using CreditCarbonAPI.Models;
using CreditCarbonAPI.Repositories.interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Linq.Expressions;

namespace CreditCarbonAPI.Repositories
{
    public class ProjectCarbonMarketsRepository : IProjectCarbonMarketsRepository
    {
        private ICarbonCreditEfRepository<ProjectCarbonMarket> _projectCarbonMarket;
        private ICarbonCreditEfRepository<ProjectCarbon> _projectCarbon;
        private ICarbonCreditEfRepository<Wallet> _wallet;
        private ICarbonCreditEfRepository<ProjectCarbonMarketsHistory> _projectCarbonMarketsHistory;
        private ICarbonCreditEfRepository<WalletTransaction> _walletTransaction;
        private readonly CarbonCreditContext _context;
        private readonly ICarbonCreditEfRepository<TechnologyType> _technologyType;


        public ProjectCarbonMarketsRepository(ICarbonCreditEfRepository<ProjectCarbonMarket> projectCarbonMarket, 
                                                ICarbonCreditEfRepository<ProjectCarbon> projectCarbon,
                                                ICarbonCreditEfRepository<Wallet> wallet,
                                                ICarbonCreditEfRepository<ProjectCarbonMarketsHistory> projectCarbonMarketHistory,
                                                ICarbonCreditEfRepository<WalletTransaction> walletTransaction,
                                                CarbonCreditContext context,
                                                ICarbonCreditEfRepository<TechnologyType> technologyType)
        {
            _projectCarbonMarket = projectCarbonMarket;
            _projectCarbon = projectCarbon;
            _wallet = wallet;
            _projectCarbonMarketsHistory = projectCarbonMarketHistory;
            _walletTransaction = walletTransaction;
            _context = context;
            _technologyType = technologyType;
        }

        public IEnumerable<ProjectCarbonMarket> Gets()
        {
            try
            {
                var p = _projectCarbon.Gets();
                var t = _technologyType.Gets();

                var listProjectCarbonMarket = _projectCarbonMarket.Gets();
                return listProjectCarbonMarket;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        private Wallet GetWallet(int userId)
        {
            var result = (from a in _wallet.Gets()
                              where a.UserId == userId
                              select a).FirstOrDefault();

            return result;
        }
        public bool BuyCarbon(BuyCarbonMarket model)
        {

            try
            {
                var userWallet = GetWallet(model.BuyForUserId);

                if (userWallet != null )
                {
                    var checkWallet = userWallet.WalletMoney - (model.UnitPrice * model.BuyAmountGreenhouseGases);
                    if (checkWallet > 0)
                    {
                        _context.Database.BeginTransaction();

                        _projectCarbonMarket.Update(new ProjectCarbonMarket()
                        {
                            ProjectCarbonMarketsId = model.ProjectCarbonMarketsId,
                            ProjectCarbonId = model.ProjectCarbonId,
                            AmountGreenhouseGases = model.AmountGreenhouseGases - model.BuyAmountGreenhouseGases,
                            Price = model.Price,
                            UnitPrice = model.UnitPrice,
                            CreatedByUserId = model.CreatedByUserId,
                            CreatedDate = model.CreatedDate,
                            UpdatedByUserId = model.BuyForUserId,
                            UpdatedDate = DateTime.Now,
                        }) ;

                        _projectCarbonMarketsHistory.Insert(new ProjectCarbonMarketsHistory()
                        {
                            ProjectCarbonMarketsId = model.ProjectCarbonMarketsId,
                            ProjectCarbonId = model.ProjectCarbonId,
                            AmountGreenhouseGasesBuy = model.BuyAmountGreenhouseGases,
                            AmountGreenhouseGasesRemaining = model.AmountGreenhouseGases - model.BuyAmountGreenhouseGases,
                            Price = model.Price,
                            UnitPrice = model.UnitPrice,
                            CreatedByUserId = model.BuyForUserId,
                            CreatedDate = DateTime.Now,
                        });

                        _wallet.Update(new Wallet()
                        {
                           WalletId = userWallet.WalletId,
                           UserId = userWallet.UserId,
                           WalletCarbon = userWallet.WalletCarbon + (decimal)model.BuyAmountGreenhouseGases,
                           WalletMoney = checkWallet,
                           CreatedDate = userWallet.CreatedDate,
                           CreatedByUserId = userWallet.CreatedByUserId,
                           UpdatedByUserId = model.BuyForUserId,
                           UpdatedDate = DateTime.Now,
                           User = new User(),
                           WalletTransactions = new List<WalletTransaction>() { }
                        });

                        //Todo
                        //_walletTransaction.Insert(new WalletTransaction()
                        //{

                        //});

                        var projectCarbon = (from a in _projectCarbon.Gets()
                                             where a.ProjectCarbonId == model.ProjectCarbonId
                                             select a).FirstOrDefault();

                        projectCarbon.ProjectCarbonId = 0;
                        projectCarbon.AmountGreenhouseGases = model.BuyAmountGreenhouseGases;
                        projectCarbon.UserId = model.BuyForUserId;
                        projectCarbon.CreatedByUserId = model.BuyForUserId;
                        projectCarbon.CreatedDate = DateTime.Now;
                        projectCarbon.UpdatedByUserId = -1;
                        projectCarbon.UpdatedDate = DateTime.Now;

                        _projectCarbon.Insert(projectCarbon);

                        _context.Database.CommitTransaction();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                _context.Database.RollbackTransaction();
                throw ex;
            }
        }   
        


    }
}