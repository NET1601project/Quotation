using Domain;
using Infrastructure.IUnitOfWork;
using Infrastructure.Common.Model.Request;
using Infrastructure.IUnitOfWork.UnitOfWorkImp;
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
        public ProjectServiceImp(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        public async  Task<Project> Add(CreateProject project)
        {
            Project p = new Project
            {
                ProjectName = project.ProjectName,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Status = project.Status,
                StaffId = project.StaffId,
                CustomerId = project.CustomerId,
            };
            var ass = _unitofWork.ProjectRepositoryImp.Add(p);
            _unitofWork.Commit();
            return ass;
        }
        

        
    }
}
