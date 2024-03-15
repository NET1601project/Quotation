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
    public class RoomDetailRepository : GenericRepositoryImp<RoomDetail>, IRoomDetailRepository
    {
        public RoomDetailRepository(AppDBContext context) : base(context)
        {
        }

        public async Task<RoomDetail> GetRoomById(Guid id)
        {
            var roomDetail = await _context.Set<RoomDetail>()
                .Include(c => c.Room)
                .ThenInclude(c => c.Project)
                .FirstOrDefaultAsync(c => c.RoomDetailId.Equals(id));
            if (roomDetail == null)
            {
                throw new Exception("not found");
            }
            return roomDetail;
        }
    }
}
