using Domain;
using Infrastructure.Common.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public interface ICustomerService
    {
        Customer GetCustomerById(Guid id);
        Task <Customer> Add(CreateCustomer create);
        Task<Customer> UpdateCustomer(Guid id );
        void DeleteCustomer(Guid id);
        Task<List<Customer>> GetAll();
        //void SaveChange();
    }
}
