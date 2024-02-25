using Application.IGenericRepository.Imp;
using Domain;
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

        public Project CreateProject(Project project)
        {
            _context.Projects.Add(project);
            return project;
        }

        public void DeleteProject(Guid id)
        {
            var project = _context.Projects.FirstOrDefault(c => c.ProjectID == id);
            _context.Projects.Remove(project);
            SaveChange();
        }

        public List<Project> GetAll()
        {
            var list = _context.Projects.ToList();
            return list;
        }

        public Project GetProjectById(Guid id)
        {
            return _context.Projects.FirstOrDefault(c => c.ProjectID == id);
        }

        public void SaveChange()
        {
            _context.SaveChanges();
        }

        public void UpdateProject(Guid id)
        {
            var project = _context.Projects.FirstOrDefault(c => c.ProjectID == id);
            _context.Projects.Update(project);
            SaveChange();
        }
    }
}
