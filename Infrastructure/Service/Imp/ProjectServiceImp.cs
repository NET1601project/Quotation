using Domain;
using Infrastructure.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service.Imp
{
    public class ProjectServiceImp : IProjectService
    {
        private readonly IUnitofWork _unitofWork;
        public Project CreateProject(Project project)
        {
            throw new NotImplementedException();
        }

        public void DeleteProject(Guid id)
        {
            _unitofWork.ProjectRepositoryImp.DeleteProject(id);
            _unitofWork.Commit();
        }

        public List<Project> GetAll()
        {
            return _unitofWork.ProjectRepositoryImp.GetAll();
        }

        public Project GetProjectById(Guid id)
        {
            return _unitofWork.ProjectRepositoryImp.GetProjectById(id);
        }

        public void UpdateProject(Guid id)
        {
            _unitofWork.ProjectRepositoryImp.UpdateProject(id);
            _unitofWork.Commit();
        }
    }
}
