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
       Customer GetCustomerById(Guid id);
       Customer CreateCustomer(Customer customer);
       void UpdateCustomer(Guid id);
       void DeleteCustomer(Guid id);
       List<Customer> GetAll();
        void SaveChange(); 
    }
}
