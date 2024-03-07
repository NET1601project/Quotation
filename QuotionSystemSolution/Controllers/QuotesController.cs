﻿using System;
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
    public class QuotesController : ControllerBase
    {
        private readonly IQuoteService _quoteService;

        public QuotesController(IQuoteService quoteService)
        {
            _quoteService = quoteService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseQuote>>> GetQuotes()
        {
            return Ok(await _quoteService.GetQuotes());
        }

        [HttpGet]
        public async Task<ActionResult<ResponseQuote>> GetQuote(Guid id)
        {
            return Ok(await _quoteService.GetQuotesByID(id));
        }
        [HttpGet]
        public async Task<ActionResult<ResponseQuote>> GetQuoteByCustomer(DateTime date)
        {
            return Ok(await _quoteService.GetQuotesByCustomer(date));
        }
        //[HttpPut]
        //public async Task<IActionResult> PutQuoteDetail(Guid id, QuoteDetail quoteDetail)
        //{

        //}

        [HttpPost]
        public async Task<ActionResult<ResponseQuote>> PostQuote(CreateQuote quoteDetail)
        {
            return Ok(await _quoteService.Add(quoteDetail));
        }

        [HttpPatch]
        public async Task<ActionResult<ResponseQuote>> UpdateQoute(Guid id, string status)
        {
            return Ok(await _quoteService.Update(id, status));

        }


    }
}