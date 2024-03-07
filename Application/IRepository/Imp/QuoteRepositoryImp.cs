using Application.IGenericRepository.Imp;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository.Imp
{
    public class QuoteRepositoryImp : GenericRepositoryImp<Quote>, IQuoteRepository
    {
        public QuoteRepositoryImp(AppDBContext context) : base(context)
        {
        }

        public async Task<List<Quote>> GetQuotes()
        {
            return await _context.Set<Quote>().ToListAsync();
        }

        public async Task<List<Quote>> GetQuotesByCustomer(Guid cutomer)
        {
            return await _context.Set<Quote>().Include(s => s.Staff).Include(c => c.Project).ThenInclude(c => c.Customer).Where(c => c.Project.CustomerId == cutomer).ToListAsync();
        }

        public async Task<List<Quote>> GetQuotesByCustomerandDate(Guid cutomer, DateTime dateTime)
        {
            return await _context.Set<Quote>().Include(s => s.Staff).Include(c => c.Project).ThenInclude(c => c.Customer).Where(c => c.Project.CustomerId == cutomer && c.QuoteDate.Date.Equals(dateTime)).ToListAsync();
        }

        public async Task<Quote> GetQuotesByID(Guid id)
        {
            return await _context.Set<Quote>().Include(s => s.Staff).Include(c => c.Project).FirstOrDefaultAsync(c => c.QuoteID == id);
        }
    }
}
