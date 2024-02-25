using Domain;
using Infrastructure.Common.Model.Request;
using Infrastructure.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service.Imp
{
    public class AccountServiceImp : IAccountService
    {
        private readonly IUnitofWork _unitofWork;
        public AccountServiceImp(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }


        public Task CreateCustomerAccount(CreateCustomer account)
        {
            var account = _unitofWork.AccountRepositoryImp.Add(account);
            _unitofWork.Commit();
            return account;
        }

        public Task<Account> Login(string UserName, string Pass)
        {
            throw new NotImplementedException();
        }
    }
}
