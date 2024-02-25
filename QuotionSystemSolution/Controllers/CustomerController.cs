using Application.IRepository;
using Domain;
using Infrastructure.Common.Model.Request;
using Infrastructure.Service;
using Infrastructure.Service.Imp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QuotionSystemSolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return Ok(await _customerService.GetAll());
        }
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(CreateCustomer customer)
        {
            return Ok(await _customerService.Add(customer);
        }
    }
}
