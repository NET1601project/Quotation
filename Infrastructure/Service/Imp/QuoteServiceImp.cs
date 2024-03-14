using AutoMapper;
using Domain;
using Infrastructure.Common.Model.Request;
using Infrastructure.Common.Model.Response;
using Infrastructure.IUnitOfWork;
using Infrastructure.Service.Security;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service.Imp
{
    public class QuoteServiceImp : IQuoteService
    {
        public readonly IUnitofWork _unitofWork;
        private readonly IMapper _mapper;
        private readonly ITokensHandler _tokensHandler;

        public QuoteServiceImp(IUnitofWork unitofWork, IMapper mapper, ITokensHandler tokensHandler)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
            _tokensHandler = tokensHandler;
        }

        public async Task<ResponseQuote> AddV2(CreateQuoteV2 create)
        {
            var q = _mapper.Map<Quote>(create);
            var username = _tokensHandler.ClaimsFromToken();
            var staff = await _unitofWork.StaffRepositoryImp.GetByUsername(username);
            q.StaffId = staff.StaffId;
            q.Status = "ACTIVE";
            q.QuoteDate = DateTime.Now;
            q.TotalAmount = 0;
            q.QuoteNumber = 0;
            var uniqueRoomIds = new HashSet<Guid>();

            foreach (var i in q.QuoteDetails)
            {
                if (uniqueRoomIds.Contains(i.MaterialId))
                {
                    throw new Exception($"Duplicate Material {i.MaterialId} found in the Qoute Details.");
                }

                uniqueRoomIds.Add(i.MaterialId);
                var details = _mapper.Map<QuoteDetails>(i);

                details.QuoteId = q.QuoteID;
                details.Price = 0;
                details.DateTime = DateTime.Now;

                var material = await _unitofWork.MaterialRepositoryImp.GetMaterialById(details.MaterialId);
                details.Price = material.UnitPrice * details.numberMaterial;
                q.TotalAmount += details.Price;
                await _unitofWork.QuoteDetailRepositoryImp.Add(details);
            }
            var quote = await _unitofWork.QuoteRepositoryImp.Add(q);

            await _unitofWork.Commit();
            return _mapper.Map<ResponseQuote>(quote);
        }

        public async Task<List<ResponseQuote>> GetQuotes()
        {
            return _mapper.Map<List<ResponseQuote>>(await _unitofWork.QuoteRepositoryImp.GetQuotes());
        }

        public async Task<List<ResponseQuote>> GetQuotesByCustomer(DateTime date)
        {
            var username = _tokensHandler.ClaimsFromToken();
            var customer = await _unitofWork.CustomerRepositoryImp.GetCustomerByUsername(username);
            if (date == DateTime.MinValue)
            {
                var list = await _unitofWork.QuoteRepositoryImp.GetQuotesByCustomer(customer.CustomerID);
                return _mapper.Map<List<ResponseQuote>>(list);
            }
            return _mapper.Map<List<ResponseQuote>>(await _unitofWork.QuoteRepositoryImp.GetQuotesByCustomerandDate(customer.CustomerID, date));
        }

        public async Task<ResponseQuote> GetQuotesByID(Guid id)
        {
            return _mapper.Map<ResponseQuote>(await _unitofWork.QuoteRepositoryImp.GetQuotesByID(id));
        }

        public async Task<ResponseQuote> Update(Guid id, string status)
        {
            var quote = await _unitofWork.QuoteRepositoryImp.GetQuotesByID(id);
            if (quote.Status.Equals(status))
            {
                throw new Exception("Can not Update STATUS " + status);
            }
            if (quote.Status.Equals("DONE") && status.Equals("INACTIVE"))
            {
                throw new Exception("Can not Update STATUS " + status);
            }
            if (quote.Status.Equals("INACTIVE") && status.Equals("DONE"))
            {
                throw new Exception("Can not Update STATUS " + status);
            }
            quote.Status = status;
            if (quote.Status.Equals("DONE"))
            {
                var project = await _unitofWork.ProjectRepositoryImp.GetProjectById(quote.ProjectID);
                await _unitofWork.ProjectRepositoryImp.Update(project);
            }
            await _unitofWork.QuoteRepositoryImp.Update(quote);
            await _unitofWork.Commit();
            return _mapper.Map<ResponseQuote>(quote);

        }
    }
}

