using Domain;
using Infrastructure.Common.Model.Request;
using Infrastructure.Common.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public interface IRoomService
    {
        //Task<ResponseRoom> Add(CreateRoom create);
        Task<List<ResponseRoomV2>> GetAll();
        //GetRoomByCustomer
        Task<List<ResponseRoomV2>> GetRoomByCustomer();

        Task<ResponseRoomV2> GetById(Guid id);
        Task<ResponseRoomV2> Edit(Guid id, CreateRoom createRoom);
        Task<ResponseRoomDetail> EditDetail(Guid id, CreateRoomDetail createRoomDetail);
        Task<ResponseRoomDetail> PostRoomDetail(CreateRoomDetailV2 createRoomDetail);
        Task<List<ResponseRoomDetail>> GetAllDetails();
        Task<ResponseRoomDetail> RemoveDetailRoom(Guid id);
    }
}
