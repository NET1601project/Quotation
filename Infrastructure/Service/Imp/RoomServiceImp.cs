using AutoMapper;
using Domain;
using Infrastructure.Common.Model.Request;
using Infrastructure.Common.Model.Response;
using Infrastructure.IUnitOfWork;
using Infrastructure.IUnitOfWork.UnitOfWorkImp;
using Infrastructure.Service.Security;
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
        private readonly ITokensHandler _tokensHandler;

        public RoomServiceImp(IUnitofWork unitofWork, IMapper mapper, ITokensHandler tokensHandler)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
            _tokensHandler = tokensHandler;
        }

        public async Task<ResponseRoom> Add(CreateRoom room)
        {
            Room r = new Room
            {
                RoomName = room.RoomName,
                Size = room.Size,
                Description = room.Description,
            };
            var ass = await _unitofWork.RoomRepositoryImp.Add(r);
            await _unitofWork.Commit();
            return _mapper.Map<ResponseRoom>(ass);
        }

        public async Task<ResponseRoomV2> Edit(Guid id, CreateRoom createRoom)
        {
            var room = await _unitofWork.RoomRepositoryImp.GetById(id);
            if (!room.Project.Status.Equals("ACTIVE"))
            {
                throw new Exception("can't update this room");
            }
            var update = _mapper.Map(createRoom, room);
            await _unitofWork.RoomRepositoryImp.Update(update);
            await _unitofWork.Commit();
            return _mapper.Map<ResponseRoomV2>(update);
        }

        public async Task<ResponseRoomDetail> EditDetail(Guid id, CreateRoomDetail createRoomDetail)
        {
            var room = await _unitofWork.RoomDetailRepositoryImp.GetRoomById(id);
            if (!room.Room.Project.Status.Equals("ACTIVE"))
            {
                throw new Exception("can't update this room");
            }
            var update = _mapper.Map(createRoomDetail, room);
            await _unitofWork.RoomDetailRepositoryImp.Update(update);
            await _unitofWork.Commit();
            return _mapper.Map<ResponseRoomDetail>(update);
        }

        public async Task<List<ResponseRoomV2>> GetAll()
        {
            return _mapper.Map<List<ResponseRoomV2>>(await _unitofWork.RoomRepositoryImp.GetAll());
        }

        public async Task<List<ResponseRoomDetail>> GetAllDetails()
        {
            return _mapper.Map<List<ResponseRoomDetail>>(await _unitofWork.RoomDetailRepositoryImp.GetAll());
        }

        public async Task<ResponseRoomV2> GetById(Guid id)
        {
            return _mapper.Map<ResponseRoomV2>(await _unitofWork.RoomRepositoryImp.GetById(id));
        }

        public async Task<List<ResponseRoomV2>> GetRoomByCustomer()
        {
            var user = _tokensHandler.ClaimsFromToken();
            var customer = await _unitofWork.CustomerRepositoryImp.GetCustomerByUsername(user);
            return _mapper.Map<List<ResponseRoomV2>>(await _unitofWork.RoomRepositoryImp.GetRoomByCustmerId(customer.CustomerID));

        }

        public async Task<ResponseRoomDetail> PostRoomDetail(CreateRoomDetailV2 createRoomDetail)
        {
            var roomdetail = _mapper.Map<RoomDetail>(createRoomDetail);
            var room = await _unitofWork.RoomRepositoryImp.GetById(roomdetail.RoomId);
            if (!room.Project.Status.Equals("ACTIVE"))
            {
                throw new Exception("can't Add this room");
            }
            await _unitofWork.RoomDetailRepositoryImp.Add(roomdetail);
            await _unitofWork.Commit();
            return _mapper.Map<ResponseRoomDetail>(roomdetail);
        }

        public async Task<ResponseRoomDetail> RemoveDetailRoom(Guid id)
        {
            var room = await _unitofWork.RoomDetailRepositoryImp.GetRoomById(id);
            _unitofWork.RoomDetailRepositoryImp.Remove(room);
            if (!room.Room.Project.Status.Equals("ACTIVE"))
            {
                throw new Exception("Khong the Delete");
            }
            return _mapper.Map<ResponseRoomDetail>(room);
        }
    }
}
