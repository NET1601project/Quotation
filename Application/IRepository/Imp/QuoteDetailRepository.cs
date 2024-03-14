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
    public class QuoteDetailRepository : GenericRepositoryImp<QuoteDetails>, IQuoteDetailRepository
    {
        public QuoteDetailRepository(AppDBContext context) : base(context)
        {
        }

        public Task<QuoteDetails> CheckByQuoteIdAndMaterialId(Guid quoteId, Guid materialId)
        {
            var check = _context.Set<QuoteDetails>().FirstOrDefaultAsync(c => c.QuoteId == quoteId && c.MaterialId == materialId);
            if (check != null)
            {
                throw new Exception("bi trung");
            }
            return check;
        }
    }
}
