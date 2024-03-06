using Application.IGenericRepository;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface IProjectRepository : IGenericRepository<Project>
    {
        Task<List<Project>> GetAll();
        Task<Project> GetProjectById(Guid id);
        Task<List<Project>> GetProjectByCustomerAndDate(Guid id,DateTime date);
        Task<List<Project>> GetProjectByDate(DateTime date);
        Task<List<Project>> GetProjectByCustomer(Guid id);
    }
}
