﻿using Application.IGenericRepository;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface IRoomRepository : IGenericRepository<Room>
    {
        Task<List<Room>> GetAll();
        Task<Room> GetById(Guid id);
        Task<List<Room>> GetRoomByCustmerId(Guid customerId);
    }
}