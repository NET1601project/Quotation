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

        public async Task<Account> CheckUsername(string username)
        {
            var check = await _context.Set<Account>()
                .Include(c => c.Staff)
                .Include(c => c.Customer)
                .FirstOrDefaultAsync(c => c.Username.ToLower().Equals(username.ToLower()));
            if (check != null)
            {
                throw new Exception("exist");
            }
            return check;
        }

        public async Task<List<Account>> GetAll()
        {
            return await _context.Set<Account>().Include(c => c.Customer).Include(c => c.Staff).ToListAsync();
        }

        public async Task<Account> Login(string username, string password)
        {
            var check = await _context.Set<Account>().FirstOrDefaultAsync(c => c.Username == username && c.Password == password);
            if (check == null)
            {
                throw new Exception("Sai password");
            }
            return check;
        }
    }
}
