using Application.IGenericRepository.Imp;
using Domain;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Account> GetAccountById(Guid id, string Username, string Password)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(c => c.Username.Equals(Username) && c.Password.Equals(Password));
            return account;
        }

        public async Task<List<Account>> GetAll()
        {
            return await _context.Set<Account>().Include(c => c.Customer).Include(c => c.Staff).ToListAsync();
        }
    }
}
