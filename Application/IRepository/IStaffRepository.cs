using Application.IGenericRepository;
using Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface IStaffRepository : IGenericRepository<Staff>
    {
        Staff GetStaffById(Guid id);
        Staff CreateStaff(Staff staff);
        void UpdateStaff(Guid id);
        void DeleteStaff(Guid id);
        List<Staff> GetAll();
        void SaveChange();

    }
}