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
using Infrastructure.Common.Model;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;

namespace QuotionSystemSolution.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountsController : ODataController
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }


        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<Account>>> GetAccounts()
        {
            return Ok(await _accountService.GetAll());
        }

        [HttpPost]
        public async Task<ActionResult<AuthenResponseMessToken>> Login(string username, string password)
        {
            return Ok(await _accountService.Login(username, password));
        }

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
