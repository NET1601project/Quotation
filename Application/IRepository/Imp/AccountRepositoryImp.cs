using Application.IGenericRepository.Imp;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository.Imp
{
    public class AccountRepositoryImp : GenericRepositoryImp<Account>, IAccountRepository
    {
        public AccountRepositoryImp(AppDBContext context) : base(context)
        {
        }
    }
}
