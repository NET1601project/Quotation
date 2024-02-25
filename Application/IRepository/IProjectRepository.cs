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
        List<Project> GetAll();
        void UpdateProject(Guid id);
        void DeleteProject(Guid id);
        Project CreateProject(Project project);
        Project GetProjectById(Guid id);
        void SaveChange();
    }
}
