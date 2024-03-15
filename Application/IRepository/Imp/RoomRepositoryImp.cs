using Application.IGenericRepository.Imp;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository.Imp
{
    public class RoomRepositoryImp : GenericRepositoryImp<Room>, IRoomRepository
    {
        public RoomRepositoryImp(AppDBContext context) : base(context)
        {
        }

        public async Task<List<Room>> GetAll()
        {
            return await _context.Set<Room>().Include(c => c.Details).Include(c => c.Project).ToListAsync();
        }

        public async Task<Room> GetById(Guid id)
        {
            var check = await _context.Set<Room>().Include(c => c.Details).Include(c => c.Project).FirstOrDefaultAsync(c => c.RoomID == id);
            if (check == null)
            {
                throw new Exception("not found");
            }
            return check;
        }

        public async Task<List<Room>> GetRoomByCustmerId(Guid customerId)
        {
            var check = await _context.Set<Room>()
                .Include(c => c.Details)
                .Include(c => c.Project)
                .ThenInclude(c => c.Customer)
                .Where(c => c.Project.CustomerId.Equals(customerId)).ToListAsync();
            //if (check == null)
            //{
            //    throw new Exception("not found");
            //}
            return check;
        }
    }
}