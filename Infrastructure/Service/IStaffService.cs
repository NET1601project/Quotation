using Domain;
using Infrastructure.Common.Model.Request;
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
        Task<Staff> Add(CreateStaff create);
        Task<Staff> UpdateStaff(Guid id);
        Task<Staff> DeleteStaff(Guid id);
        Task<List<Staff>> GetAll();
    }
}
