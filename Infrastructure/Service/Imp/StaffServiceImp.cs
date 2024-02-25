using Domain;
using Infrastructure.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service.Imp
{
    public class StaffServiceImp : IStaffService
    {
        private readonly IUnitofWork _unitOfWork;
        public Staff CreateStaff(Staff staff)
        {
            throw new NotImplementedException();
        }

        public void DeleteStaff(Guid id)
        {
           _unitOfWork.StaffRepositoryImp.DeleteStaff(id);
            _unitOfWork.Commit();
        }

        public List<Staff> GetAll()
        {
            return _unitOfWork.StaffRepositoryImp.GetAll();
        }

        public Staff GetStaffById(Guid id)
        {
            return _unitOfWork.StaffRepositoryImp.GetStaffById(id);
        }

        public void UpdateStaff(Guid id)
        {
            _unitOfWork.StaffRepositoryImp.UpdateStaff(id);
            _unitOfWork.Commit();
        }
    }
}
