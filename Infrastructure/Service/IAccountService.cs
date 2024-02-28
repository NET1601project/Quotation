using Domain;
using Infrastructure.Common.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public interface IAccountService
    {

        Task<Account> Login(String UserName, String Pass);
        Task<Account> Add(CreateAccount create);
        Task<Account> GetAccountById(Guid id , String UserName, String Pass);
    }
}
