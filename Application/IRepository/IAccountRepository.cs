using Application.IGenericRepository;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
    }
}
