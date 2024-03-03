using Domain;
using Infrastructure.IUnitOfWork;
using Infrastructure.Common.Model.Request;
using Infrastructure.IUnitOfWork.UnitOfWorkImp;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using Infrastructure.Common.Model.Response;
using AutoMapper;

namespace Infrastructure.Service.Imp
{
    public class StaffServiceImp : IStaffService
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IMapper _mapper;

        public StaffServiceImp(IUnitofWork unitofWork, IMapper mapper)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
        }

        public async Task<ResponseStaff> Add(CreateStaff staff)
        {
            Staff s = new Staff
            {
                StaffName = staff.StaffName,
                CreateDate = DateTime.Now,
                Contact = staff.Contact,
            };
            Account a = new Account
            {
                Username = staff.Username,
                Password = staff.Password,
                Role = "STAFF",
                Staff = s,
            };
            var ass = await _unitofWork.StaffRepositoryImp.Add(s);
            await _unitofWork.AccountRepositoryImp.Add(a);

            await _unitofWork.Commit();
            return _mapper.Map<ResponseStaff>(ass);
        }

        public async Task<List<ResponseStaff>> GetStaff()
        {
            return _mapper.Map<List<ResponseStaff>>(await _unitofWork.StaffRepositoryImp.GetAll());
        }
    }
}
