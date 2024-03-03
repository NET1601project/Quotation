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
        Task<List<ResponseQuote>> GetQuotes();
        Task<ResponseQuote> GetQuotesByID(Guid id);

    }
}
