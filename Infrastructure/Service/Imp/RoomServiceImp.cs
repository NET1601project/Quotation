using Domain;
using Infrastructure.Common.Model.Request;
using Infrastructure.IUnitOfWork;
using Infrastructure.IUnitOfWork.UnitOfWorkImp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service.Imp
{
    public class RoomServiceImp : IRoomService
    {
        public readonly IUnitofWork _unitofWork;
        public RoomServiceImp(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        public async Task<Room> Add(CreateRoom room)
        {
            Room r = new Room
            {
                RoomName = room.RoomName,
                Size = room.Size, 
                Description = room.Description,
                ProjectId = room.ProjectId,
            };
            var ass = _unitofWork.RoomRepositoryImp.Add(r);
            _unitofWork.Commit();
            return ass;
        }
    }
}
