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
    public interface IProjectService
    {
        Task<ResponseProject> Add(CreateProject project);
        Task<ResponseProjectV2> AddV2(CreateProjectV2 project);
        Task<ResponseProjectV2> Edit(Guid id,UpdateProject project);

        Task<List<ResponseProjectV2>> GetProjects();
        Task<List<ResponseProjectV2>> GetProjectsStatusACTIVE();
        Task<ResponseProject> GetProjectById(Guid id);
        Task<List<ResponseProject>> GetProjectByCustomerAndDate(DateTime date);
        Task<List<ResponseProject>> GetProjectByStaffAndDate(DateTime date);

    }
}
