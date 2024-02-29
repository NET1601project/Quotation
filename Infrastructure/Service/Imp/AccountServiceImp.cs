using AutoMapper;
using Domain;
using Infrastructure.Common.Model.Request;
using Infrastructure.Common.Model.Response;
using Infrastructure.IUnitOfWork;
using Infrastructure.IUnitOfWork.UnitOfWorkImp;
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
        private readonly IMapper _mapper;

        public AccountServiceImp(IUnitofWork unitofWork, IMapper mapper)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
        }

        public async Task<Account> Add(CreateAccount account)
        {
            Account a = new Account
            {
                Username = account.Username,
                Password = account.Password,
                Role = account.Role,
            };
            var ass = await _unitofWork.AccountRepositoryImp.Add(a);
            await _unitofWork.Commit();
            return ass;
        }

        public Task<Account> GetAccountById(Guid id, string UserName, string Pass)
        {
            return _unitofWork.AccountRepositoryImp.GetAccountById(id, UserName, Pass);
        }

        public async Task<List<ResponseAccount>> GetAll()
        {
            var account = await _unitofWork.AccountRepositoryImp.GetAll();
            return _mapper.Map<List<ResponseAccount>>(account);
        }

        public async Task<Account> Login(string UserName, string Pass)
        {
            throw new NotImplementedException();
        }
    }
}
