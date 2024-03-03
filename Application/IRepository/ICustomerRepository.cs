using Application.IGenericRepository;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<List<Customer>> GetAll();
        Task<Customer> GetCustomerById(Guid id);
        Task<Customer> GetCustomerByUsername(string username);
    }
}
