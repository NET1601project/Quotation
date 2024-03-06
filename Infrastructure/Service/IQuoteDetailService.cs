using Infrastructure.Common.Model.Request;
using Infrastructure.Common.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public interface IQuoteDetailService
    {
        Task<ResponseQuote> Add(CreateQuote create);
        Task<ResponseQuote> Update(Guid id,string status);
        Task<List<ResponseQuote>> GetQuotes();
        Task<List<ResponseQuote>> GetQuotesByCustomer(DateTime date);
        Task<ResponseQuote> GetQuotesByID(Guid id);

    }
}
