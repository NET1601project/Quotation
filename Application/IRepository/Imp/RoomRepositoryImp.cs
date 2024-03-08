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
            return await _context.Set<Room>().ToListAsync();
        }

        public async Task<Room> GetById(Guid id)
        {
            return await _context.Set<Room>().Include(c => c.Details).FirstOrDefaultAsync(c => c.RoomID == id);
        }
    }
}