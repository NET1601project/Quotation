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
using Infrastructure.Common.Model.Request;

namespace QuotionSystemSolution.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class QuoteDetailsController : ControllerBase
    {
        private readonly IQuoteDetailService _quoteService;

        public QuoteDetailsController(IQuoteDetailService quoteService)
        {
            _quoteService = quoteService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseQuote>>> GetQuoteDetails()
        {
            return Ok(await _quoteService.GetQuotes());
        }

        //[HttpGet]
        //public async Task<ActionResult<QuoteDetail>> GetQuoteDetail(Guid id)
        //{

        //}

        //[HttpPut]
        //public async Task<IActionResult> PutQuoteDetail(Guid id, QuoteDetail quoteDetail)
        //{

        //}

        [HttpPost]
        public async Task<ActionResult<ResponseQuote>> PostQuoteDetails(CreateQuote quoteDetail)
        {
            return Ok(await _quoteService.Add(quoteDetail));
        }

        //[HttpDelete]
        //public async Task<IActionResult> DeleteQuoteDetail(Guid id)
        //{
        //}


    }
}
