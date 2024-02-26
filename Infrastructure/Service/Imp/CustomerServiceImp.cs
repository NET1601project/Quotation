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
            Customer c= new Customer
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

         var  ass =  _unitofWork.CustomerRepositoryImp.Add(c);
             _unitofWork.AccountRepositoryImp.Add(a);

            _unitofWork.Commit();
            return ass;
        }

        public void DeleteCustomer(Guid id)
        {
            _unitofWork.CustomerRepositoryImp.DeleteCustomer(id);
            _unitofWork.Commit();
        }

        public  async Task<List<Customer>> GetAll()
        {
            return _unitofWork.CustomerRepositoryImp.GetAll();
        }

        public Customer GetCustomerById(Guid id)
        {
            return _unitofWork.CustomerRepositoryImp.GetCustomerById(id);
        }

      

        public void UpdateCustomer(Guid id)
        {
            _unitofWork.CustomerRepositoryImp.UpdateCustomer(id);
            _unitofWork.Commit();
        }

        Task<Customer> ICustomerService.DeleteCustomer(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<Customer> ICustomerService.UpdateCustomer(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
