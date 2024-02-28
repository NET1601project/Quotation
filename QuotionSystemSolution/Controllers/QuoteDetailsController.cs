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
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteDetailsController : ControllerBase
    {
        private readonly AppDBContext _context;

        public QuoteDetailsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/QuoteDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuoteDetail>>> GetQuoteDetails()
        {
          if (_context.QuoteDetails == null)
          {
              return NotFound();
          }
            return await _context.QuoteDetails.ToListAsync();
        }

        // GET: api/QuoteDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QuoteDetail>> GetQuoteDetail(Guid id)
        {
          if (_context.QuoteDetails == null)
          {
              return NotFound();
          }
            var quoteDetail = await _context.QuoteDetails.FindAsync(id);

            if (quoteDetail == null)
            {
                return NotFound();
            }

            return quoteDetail;
        }

        // PUT: api/QuoteDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuoteDetail(Guid id, QuoteDetail quoteDetail)
        {
            if (id != quoteDetail.QuoteID)
            {
                return BadRequest();
            }

            _context.Entry(quoteDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuoteDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/QuoteDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<QuoteDetail>> PostQuoteDetail(QuoteDetail quoteDetail)
        {
          if (_context.QuoteDetails == null)
          {
              return Problem("Entity set 'AppDBContext.QuoteDetails'  is null.");
          }
            _context.QuoteDetails.Add(quoteDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuoteDetail", new { id = quoteDetail.QuoteID }, quoteDetail);
        }

        // DELETE: api/QuoteDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuoteDetail(Guid id)
        {
            if (_context.QuoteDetails == null)
            {
                return NotFound();
            }
            var quoteDetail = await _context.QuoteDetails.FindAsync(id);
            if (quoteDetail == null)
            {
                return NotFound();
            }

            _context.QuoteDetails.Remove(quoteDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuoteDetailExists(Guid id)
        {
            return (_context.QuoteDetails?.Any(e => e.QuoteID == id)).GetValueOrDefault();
        }
    }
}
