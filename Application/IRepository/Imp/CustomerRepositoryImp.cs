using Application.IGenericRepository.Imp;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository.Imp
{
    public class CustomerRepositoryImp : GenericRepositoryImp<Customer>, ICustomerRepository
    {
        public CustomerRepositoryImp(AppDBContext context) : base(context)
        {
        }

        public async Task<List<Customer>> GetAll()
        {
            return await _context.Set<Customer>().Include(c => c.Account).ToListAsync();
        }

        public async Task<Customer> GetCustomerById(Guid id)
        {
            return await _context.Set<Customer>().Include(c => c.Account).FirstOrDefaultAsync(c => c.CustomerID == id);
        }

        public async Task<Customer> GetCustomerByUsername(string username)
        {
            var customer = await _context.Set<Customer>().Include(c => c.Account).FirstOrDefaultAsync(c => c.Account.Username.ToLower().Equals(username.ToLower()));
            if (customer == null)
            {
                throw new Exception("not found");
            }
            return customer;
        }
    }
}
