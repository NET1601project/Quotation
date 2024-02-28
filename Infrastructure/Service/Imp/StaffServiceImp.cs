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

namespace Infrastructure.Service.Imp
{
    public class StaffServiceImp : IStaffService
    {
        private readonly IUnitofWork _unitofWork;
        public StaffServiceImp(IUnitofWork unitOfWork)
        {
            _unitofWork = unitOfWork;
        }

        public async Task<Staff> Add(CreateStaff staff)
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
                Role = staff.Role,
                Staff = s,
            };
            var ass = await _unitofWork.StaffRepositoryImp.Add(s);
            await _unitofWork.AccountRepositoryImp.Add(a);

             await _unitofWork.Commit();
            return ass;
        }

    }
}
