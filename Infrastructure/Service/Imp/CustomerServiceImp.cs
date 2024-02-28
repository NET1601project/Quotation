using Domain;
using Infrastructure.Common.Model.Request;
using Infrastructure.IUnitOfWork;
using Infrastructure.IUnitOfWork.UnitOfWorkImp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service.Imp
{
    public class CustomerServiceImp : ICustomerService
    {
        private readonly IUnitofWork _unitofWork;
        public CustomerServiceImp(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        public async Task<Customer> Add(CreateCustomer customer)
        {
            Customer c = new Customer
            {
                Address = customer.Address,
                CreateDate = DateTime.Now,
                Email = customer.Email,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Phone = customer.Phone,

            };
            Account a = new Account
            {
                Username = customer.Username,
                Password = customer.Password,
                Role = customer.Role,
                Customer = c
            };

            var ass = await _unitofWork.CustomerRepositoryImp.Add(c);
            await _unitofWork.AccountRepositoryImp.Add(a);

            await _unitofWork.Commit();
            return ass;
        }


    }
}
