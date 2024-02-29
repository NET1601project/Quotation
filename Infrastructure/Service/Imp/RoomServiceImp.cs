using AutoMapper;
using Domain;
using Infrastructure.Common.Model.Request;
using Infrastructure.Common.Model.Response;
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
        private readonly IMapper _mapper;

        public RoomServiceImp(IUnitofWork unitofWork, IMapper mapper)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
        }

        public async Task<ResponseRoom> Add(CreateRoom room)
        {
            Room r = new Room
            {
                RoomName = room.RoomName,
                Size = room.Size,
                Description = room.Description,
                ProjectId = room.ProjectId,
            };
            var ass = await _unitofWork.RoomRepositoryImp.Add(r);
            await _unitofWork.Commit();
            return _mapper.Map<ResponseRoom>(ass);
        }

        public async Task<List<ResponseRoom>> GetAll()
        {
            return _mapper.Map<List<ResponseRoom>>(await _unitofWork.RoomRepositoryImp.GetAll());
        }
    }
}
