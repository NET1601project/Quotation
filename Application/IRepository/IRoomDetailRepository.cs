﻿using Application.IGenericRepository;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface IRoomDetailRepository : IGenericRepository<RoomDetail>
    {
        Task<RoomDetail> GetRoomById(Guid id);
        Task<List<RoomDetail>> GetAll();
        
    }
}
