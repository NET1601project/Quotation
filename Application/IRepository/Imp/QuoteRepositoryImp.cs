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
    public class QuoteRepositoryImp : GenericRepositoryImp<Quote>, IQuoteDetailRepository
    {
        public QuoteRepositoryImp(AppDBContext context) : base(context)
        {
        }

        public async Task<List<Quote>> GetQuotes()
        {
            return await _context.Set<Quote>().ToListAsync();
        }

        public async Task<Quote> GetQuotesByID(Guid id)
        {
            return await _context.Set<Quote>().Include(c => c.Material).Include(s => s.Staff).Include(c => c.Project).FirstOrDefaultAsync(c => c.QuoteID == id);
        }
    }
}
