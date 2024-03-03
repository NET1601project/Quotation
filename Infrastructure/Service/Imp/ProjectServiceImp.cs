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
using Infrastructure.Service.Security;

namespace Infrastructure.Service.Imp
{
    public class ProjectServiceImp : IProjectService
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IMapper _mapper;
        private readonly ITokensHandler _tokensHandler;

        public ProjectServiceImp(IUnitofWork unitofWork, IMapper mapper, ITokensHandler tokensHandler)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
            _tokensHandler = tokensHandler;
        }

        public async Task<ResponseProject> Add(CreateProject project)
        {

            var customerCheck = _tokensHandler.ClaimsFromToken();
            var customer = await _unitofWork.CustomerRepositoryImp.GetCustomerByUsername(customerCheck);

            Project p = new Project
            {
                ProjectName = project.ProjectName,
                StartDate = DateTime.Now,
                EndDate = project.EndDate,
                CustomerId = customer.CustomerID
            };
            p.Status = "ACTIVE";
            var ass = await _unitofWork.ProjectRepositoryImp.Add(p);
            await _unitofWork.Commit();
            return _mapper.Map<ResponseProject>(ass);
        }

        public async Task<List<ResponseProject>> GetProjects()
        {
            return _mapper.Map<List<ResponseProject>>(await _unitofWork.ProjectRepositoryImp.GetAll());
        }
    }
}
