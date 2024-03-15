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
    public class ProjectRepositoryImp : GenericRepositoryImp<Project>, IProjectRepository
    {
        public ProjectRepositoryImp(AppDBContext context) : base(context)
        {
        }

        public async Task<List<Project>> GetAll()
        {
            return await _context.Set<Project>().Include(c => c.Rooms).ThenInclude(c => c.Details).OrderByDescending(c => c.StartDate).ToListAsync();
        }
       
        public async Task<List<Project>> GetAllACTIVE()
        {
            return await _context.Set<Project>().Include(c => c.Rooms).ThenInclude(c => c.Details).OrderByDescending(c => c.StartDate).Where(c => c.Status.Equals("ACTIVE")).ToListAsync();
        }

        public async Task<List<Project>> GetProjectByCustomer(Guid id)
        {
            return await _context.Set<Project>().Include(c => c.Rooms).ThenInclude(c => c.Details).Include(c => c.Customer).Where(c => c.CustomerId.Equals(id)).OrderByDescending(c => c.StartDate).ToListAsync();
        }

        public async Task<List<Project>> GetProjectByCustomerAndDate(Guid id, DateTime date)
        {

            return await _context.Set<Project>().Include(c => c.Rooms).ThenInclude(c => c.Details).Include(c => c.Customer).Where(c => c.CustomerId.Equals(id) && c.StartDate.Date == (date.Date)).OrderByDescending(c => c.StartDate).ToListAsync();
        }

        public async Task<List<Project>> GetProjectByDate(DateTime date)
        {
            return await _context.Set<Project>().Include(c => c.Rooms).ThenInclude(c => c.Details).Include(c => c.Customer).Where(c => c.StartDate.Date == (date.Date)).OrderByDescending(c => c.StartDate).ToListAsync();
        }

        public async Task<Project> GetProjectById(Guid id)
        {
            return await _context.Set<Project>().Include(c => c.Rooms).ThenInclude(c => c.Details).OrderByDescending(c => c.StartDate).FirstOrDefaultAsync(c => c.ProjectID == id);
        }
    }
}
