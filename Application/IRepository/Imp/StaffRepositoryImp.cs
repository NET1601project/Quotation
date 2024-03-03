using Application.IGenericRepository.Imp;
using Domain;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Staff>> GetAll()
        {
            return await _context.Set<Staff>().Include(c => c.Account).ToListAsync();
        }

        public async Task<Staff> GetById(Guid id)
        {
            return await _context.Set<Staff>().Include(c => c.Account).FirstOrDefaultAsync(c => c.StaffId == id);
        }

        public async Task<Staff> GetByUsername(string username)
        {
            return await _context.Set<Staff>().Include(c => c.Account).FirstOrDefaultAsync(c => c.Account.Username.ToLower().Equals(username.ToLower()));
        }
    }
}
