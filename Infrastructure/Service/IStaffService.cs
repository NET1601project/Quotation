﻿using Domain;
using Infrastructure.Common.Model.Request;
using Infrastructure.Common.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public interface IStaffService
    {
        Task<ResponseStaff> Add(CreateStaff create);
        Task<List<ResponseStaff>> GetStaff();
    }
}
