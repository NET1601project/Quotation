using Domain;
using Infrastructure.IUnitOfWork;
using Infrastructure.Common.Model.Request;
using Infrastructure.IUnitOfWork.UnitOfWorkImp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Common.Model.Response;
using AutoMapper;

namespace Infrastructure.Service.Imp
{
    public class ProjectServiceImp : IProjectService
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IMapper _mapper;

        public ProjectServiceImp(IUnitofWork unitofWork, IMapper mapper)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
        }

        public async Task<Project> Add(CreateProject project)
        {
            Project p = new Project
            {
                ProjectName = project.ProjectName,
                StartDate = DateTime.Now,
                EndDate = project.EndDate,
                Status = project.Status,
                StaffId = project.StaffId,
                CustomerId = project.CustomerId,
            };
            var ass = await _unitofWork.ProjectRepositoryImp.Add(p);
            await _unitofWork.Commit();
            return ass;
        }

        public async Task<List<ResponseProject>> GetProjects()
        {
            return _mapper.Map<List<ResponseProject>>(await _unitofWork.ProjectRepositoryImp.GetAll());
        }
    }
}
