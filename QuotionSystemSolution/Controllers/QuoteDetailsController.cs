using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Application;
using Domain;

namespace QuotionSystemSolution.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class QuoteDetailsController : ControllerBase
    {
        private readonly AppDBContext _context;

        public QuoteDetailsController(AppDBContext context)
        {
            _context = context;
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<QuoteDetail>>> GetQuoteDetails()
        //{

        //}

        //[HttpGet]
        //public async Task<ActionResult<QuoteDetail>> GetQuoteDetail(Guid id)
        //{

        //}

        //[HttpPut]
        //public async Task<IActionResult> PutQuoteDetail(Guid id, QuoteDetail quoteDetail)
        //{

        //}

        //[HttpPost]
        //public async Task<ActionResult<QuoteDetail>> PostQuoteDetail(QuoteDetail quoteDetail)
        //{
        //}

        //[HttpDelete]
        //public async Task<IActionResult> DeleteQuoteDetail(Guid id)
        //{
        //}


    }
}
