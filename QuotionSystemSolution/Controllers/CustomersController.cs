using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Application;
using Domain;
using Infrastructure.Service;
using Infrastructure.Common.Model.Request;
using Infrastructure.Common.Model.Response;

namespace QuotionSystemSolution.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerServices _customerService;

        public CustomersController(ICustomerServices customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseCustomer>>> GetCustomers()
        {
            return Ok(await _customerService.GetCustomers());
        }
        [HttpGet]
        public async Task<ActionResult<ResponseCustomer>> GetCustomerById(Guid customerId)
        {
            return Ok(await _customerService.GetCustomerById(customerId));
        }

        [HttpPost]
        public async Task<ActionResult<ResponseCustomer>> PostCustomers(CreateCustomer customer)
        {
          return Ok(await _customerService.Add(customer));
        }

        
    }
}
