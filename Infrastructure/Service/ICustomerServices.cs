using Domain;
using Infrastructure.Common.Model.Request;
using Infrastructure.Common.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public interface ICustomerServices
    {
        Task<List<ResponseCustomer>> GetCustomers();
        Task<ResponseCustomer> Add(CreateCustomer customer);

    }
}
