using Application.IGenericRepository;
using Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface IStaffRepository : IGenericRepository<Staff>
    {
        Task<List<Staff>> GetAll();

    }
}