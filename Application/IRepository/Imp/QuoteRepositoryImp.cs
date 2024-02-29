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
    public class QuoteRepositoryImp : GenericRepositoryImp<QuoteDetail>, IQuoteDetailRepository
    {
        public QuoteRepositoryImp(AppDBContext context) : base(context)
        {
        }

        public async Task<List<QuoteDetail>> GetQuotes()
        {
            return await _context.Set<QuoteDetail>().ToListAsync();
        }
    }
}
