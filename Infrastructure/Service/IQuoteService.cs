using Infrastructure.Common.Model.Request;
using Infrastructure.Common.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public interface IQuoteService
    {
        Task<ResponseQuote> AddV2(CreateQuoteV2 create);
        Task<ResponseQuote> Update(Guid id,string status);
        Task<List<ResponseQuote>> GetQuotes();
        Task<List<ResponseQuote>> GetQuotesByCustomer(DateTime date);
        Task<ResponseQuote> GetQuotesByID(Guid id);

    }
}
