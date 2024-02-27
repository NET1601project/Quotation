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
            var ass = _unitofWork.StaffRepositoryImp.Add(s);
            _unitofWork.AccountRepositoryImp.Add(a);

            _unitofWork.Commit();
            return ass;
        }
       

        public Task<Staff> DeleteStaff(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Staff>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Staff GetStaffById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Staff> UpdateStaff(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
