using Application.IGenericRepository.Imp;
using Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository.Imp
{
    public class StaffRepositoryImp : GenericRepositoryImp<Staff>, IStaffRepository
    {
        public StaffRepositoryImp(AppDBContext context) : base(context)
        {
        }

        public Staff CreateStaff(Staff staff)
        {
            _context.Staff.Add(staff);
            return staff;
        }

        public void DeleteStaff(Guid id)
        {
            var staff = _context.Staff.FirstOrDefault(c => c.StaffId == id);
            _context.Staff.Remove(staff);
            SaveChange();
        }

        public List<Staff> GetAll()
        {
            var list =_context.Staff.ToList();
            return list;
        }

        public Staff GetStaffById(Guid id)
        {
            return _context.Staff.FirstOrDefault(c => c.StaffId == id);
        }

        public void SaveChange()
        {
            _context.SaveChanges();
        }

        public void UpdateStaff(Guid id)
        {
            var staff = _context.Staff.FirstOrDefault( c => c.StaffId == id);
            _context.Staff.Update(staff);
            SaveChange();
        }
    }
}
