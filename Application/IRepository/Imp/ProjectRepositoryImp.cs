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
            return await _context.Set<Project>().ToListAsync();
        }
    }
}
