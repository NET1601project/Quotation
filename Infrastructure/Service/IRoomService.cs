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
        Task<List<ResponseRoom>> GetAll();
        Task<ResponseRoomV2> GetById(Guid id);
    }
}
