using Application.IGenericRepository.Imp;
using Domain;
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
    }
}
