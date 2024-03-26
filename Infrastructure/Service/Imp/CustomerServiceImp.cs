using AutoMapper;
using Domain;
using Infrastructure.Common.Model.Request;
using Infrastructure.Common.Model.Response;
using Infrastructure.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service.Imp
{
    public class CustomerServiceImp : ICustomerServices
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IMapper _mapper;

        public CustomerServiceImp(IUnitofWork unitofWork, IMapper mapper)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
        }

        public async Task<ResponseCustomer> Add(CreateCustomer customer)
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
                Role = "CUSTOMER",
                Customer = c
            };
            await _unitofWork.CustomerRepositoryImp.CheckEmail(c.Email);
            await _unitofWork.AccountRepositoryImp.CheckUsername(a.Username);
            var ass = await _unitofWork.CustomerRepositoryImp.Add(c);
            await _unitofWork.AccountRepositoryImp.Add(a);

            await _unitofWork.Commit();
            return _mapper.Map<ResponseCustomer>(ass);
        }

        public async Task<ResponseCustomer> GetCustomerById(Guid guid)
        {
            return _mapper.Map<ResponseCustomer>(await _unitofWork.CustomerRepositoryImp.GetCustomerById(guid));
        }

        public async Task<List<ResponseCustomer>> GetCustomers()
        {
            return _mapper.Map<List<ResponseCustomer>>(await _unitofWork.CustomerRepositoryImp.GetAll());
        }


    }
}
