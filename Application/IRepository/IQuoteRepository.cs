﻿using Application.IGenericRepository;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface IQuoteRepository : IGenericRepository<Quote>
    {
        Task<List<Quote>> GetQuotes();
        Task<Quote> GetQuotesByID(Guid id);
        Task<List<Quote>> GetQuotesByCustomerandDate(Guid cutomer, DateTime dateTime);
        Task<List<Quote>> GetQuotesByCustomer(Guid cutomer);
    }
}