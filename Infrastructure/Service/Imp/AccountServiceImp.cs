using AutoMapper;
using Domain;
using Infrastructure.Common.Model;
using Infrastructure.Common.Model.Request;
using Infrastructure.Common.Model.Response;
using Infrastructure.IUnitOfWork;
using Infrastructure.Service.Security;


namespace Infrastructure.Service.Imp
{
    public class AccountServiceImp : IAccountService
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IMapper _mapper;
        private readonly ITokensHandler _tokensHandler;

        public AccountServiceImp(IUnitofWork unitofWork, IMapper mapper, ITokensHandler tokensHandler)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
            _tokensHandler = tokensHandler;
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

        public async Task<List<ResponseAccount>> GetAll()
        {
            var account = await _unitofWork.AccountRepositoryImp.GetAll();
            return _mapper.Map<List<ResponseAccount>>(account);
        }

        public async Task<AuthenResponseMessToken> Login(string UserName, string Pass)
        {
            var account = await _unitofWork.AccountRepositoryImp.Login(UserName, Pass);
            var token = _tokensHandler.CreateAccessToken(account);
            return _mapper.Map<AuthenResponseMessToken>(token);
        }

        
    }
}
