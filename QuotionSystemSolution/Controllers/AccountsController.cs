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
using Infrastructure.Common.Model.Response;

namespace QuotionSystemSolution.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseAccount>>> GetAccounts()
        {
            return await _accountService.GetAll();
        }

        //[HttpGet]
        //public async Task<ActionResult<Account>> GetAccount(Guid id)
        //{

        //}

        //[HttpPut]
        //public async Task<IActionResult> PutAccount(Guid id, Account account)
        //{

        //}

        //[HttpPost]
        //public async Task<ActionResult<Account>> PostAccount(Account account)
        //{
        //}

        //[HttpDelete]
        //public async Task<IActionResult> DeleteAccount(Guid id)
        //{

        //}


    }
}
