﻿using Domain;
using Infrastructure.IUnitOfWork;
using Infrastructure.Common.Model.Request;
using Infrastructure.IUnitOfWork.UnitOfWorkImp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service.Imp
{
    public class ProjectServiceImp : IProjectService
    {
        private readonly IUnitofWork _unitofWork;
        public ProjectServiceImp(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        public async  Task<Project> Add(CreateProject project)
        {
            Project p = new Project
            {
                ProjectName = project.ProjectName,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Status = project.Status,
                StaffId = project.StaffId,
                CustomerId = project.CustomerId,
            };
            var ass = _unitofWork.ProjectRepositoryImp.Add(p);
            _unitofWork.Commit();
            return ass;
        }

        public void DeleteProject(Guid id)
        {
            _unitofWork.ProjectRepositoryImp.DeleteProject(id);
            _unitofWork.Commit();
        }

        public List<Project> GetAll()
        {
            return _unitofWork.ProjectRepositoryImp.GetAll();
        }

        public Project GetProjectById(Guid id)
        {
            return _unitofWork.ProjectRepositoryImp.GetProjectById(id);
        }

        public void UpdateProject(Guid id)
        {
            _unitofWork.ProjectRepositoryImp.UpdateProject(id);
            _unitofWork.Commit();
        }
    }
}
