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
            var projects = _mapper.Map<Project>(project);
            projects.StartDate = DateTime.Now;
            projects.Status = "ACTIVE";
            projects.CustomerId = customer.CustomerID;

            foreach (var i in projects.Rooms)
            {

                var room = _mapper.Map<Room>(i);
                await _unitofWork.RoomRepositoryImp.Add(room);
            }
            await _unitofWork.ProjectRepositoryImp.Add(projects);

            await _unitofWork.Commit();
            return _mapper.Map<ResponseProject>(projects);
        }

        public async Task<ResponseProjectV2> AddV2(CreateProjectV2 project)
        {
            var customerCheck = _tokensHandler.ClaimsFromToken();
            var customer = await _unitofWork.CustomerRepositoryImp.GetCustomerByUsername(customerCheck);
            var projects = _mapper.Map<Project>(project);
            projects.StartDate = DateTime.Now;
            projects.Status = "ACTIVE";
            projects.CustomerId = customer.CustomerID;

            foreach (var i in projects.Rooms)
            {

                var room = _mapper.Map<Room>(i);
                await _unitofWork.RoomRepositoryImp.Add(room);
                foreach (var y in i.Details)
                {
                    var roomdetail = _mapper.Map<RoomDetail>(y);
                    roomdetail.RoomId = room.RoomID;
                    roomdetail.DateTime = DateTime.Now;
                    await _unitofWork.RoomDetailRepositoryImp.Add(roomdetail);
                }
            }
            await _unitofWork.ProjectRepositoryImp.Add(projects);

            await _unitofWork.Commit();
            return _mapper.Map<ResponseProjectV2>(projects);
        }

        public async Task<List<ResponseProject>> GetProjectByCustomerAndDate(DateTime date)
        {
            var customerCheck = _tokensHandler.ClaimsFromToken();
            var customer = await _unitofWork.CustomerRepositoryImp.GetCustomerByUsername(customerCheck);
            if (date == DateTime.MinValue)
            {
                return _mapper.Map<List<ResponseProject>>(await _unitofWork.ProjectRepositoryImp.GetProjectByCustomer(customer.CustomerID));
            }
            return _mapper.Map<List<ResponseProject>>(await _unitofWork.ProjectRepositoryImp.GetProjectByCustomerAndDate(customer.CustomerID, date));
        }

        public async Task<ResponseProject> GetProjectById(Guid id)
        {
            return _mapper.Map<ResponseProject>(await _unitofWork.ProjectRepositoryImp.GetProjectById(id));
        }

        public async Task<List<ResponseProject>> GetProjectByStaffAndDate(DateTime date)
        {
            if (date == DateTime.MinValue)
            {
                return _mapper.Map<List<ResponseProject>>(await _unitofWork.ProjectRepositoryImp.GetAll());
            }
            return _mapper.Map<List<ResponseProject>>(await _unitofWork.ProjectRepositoryImp.GetProjectByDate(date));
        }

        public async Task<List<ResponseProject>> GetProjects()
        {
            return _mapper.Map<List<ResponseProject>>(await _unitofWork.ProjectRepositoryImp.GetAll());
        }
    }
}
