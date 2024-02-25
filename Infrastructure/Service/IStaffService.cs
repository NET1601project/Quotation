using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public interface IStaffService
    {
        Staff GetStaffById(Guid id);
        Staff CreateStaff(Staff staff);
        void UpdateStaff(Guid id);
        void DeleteStaff(Guid id);
        List<Staff> GetAll();
    }
}
