using Domain;
using Infrastructure.Common.Model;
using Infrastructure.Common.Model.Request;
using Infrastructure.Common.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public interface IAccountService
    {
        Task<AuthenResponseMessToken> Login(string UserName, string Pass);
        Task<Account> Add(CreateAccount create);
        Task<List<ResponseAccount>> GetAll();
    }
}
