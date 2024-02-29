using AutoMapper;
using Domain;
using Infrastructure.Common.Model.Request;
using Infrastructure.Common.Model.Response;
using Infrastructure.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service.Imp
{
    public class QuoteDetailServiceImp : IQuoteDetailService
    {
        public readonly IUnitofWork _unitofWork;
        private readonly IMapper _mapper;

        public QuoteDetailServiceImp(IUnitofWork unitofWork, IMapper mapper)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
        }

        public async Task<ResponseQuote> Add(CreateQuote create)
        {
            var q = _mapper.Map<QuoteDetail>(create);
            q.Status = "ACTIVE";
            q.QuoteDate = DateTime.Now;
            q.TotalAmount = 0;
            var quote = await _unitofWork.QuoteRepositoryImp.Add(q);
            await _unitofWork.Commit();
            return _mapper.Map<ResponseQuote>(quote);
        }

        public async Task<List<ResponseQuote>> GetQuotes()
        {
            return _mapper.Map<List<ResponseQuote>>(await _unitofWork.QuoteRepositoryImp.GetQuotes());
        }
    }
}

