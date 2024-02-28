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

namespace QuotionSystemSolution.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        //{
        //    return Ok(await _customerService.GetAll());
        //}
        
       
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomers(CreateCustomer customer)
        {
          return Ok(await _customerService.Add(customer));
        }

        
    }
}
