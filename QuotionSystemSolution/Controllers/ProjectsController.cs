using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Application;
using Domain;
using Infrastructure.Service;
using Infrastructure.Common.Model.Request;
using Infrastructure.Common.Model.Response;
using Microsoft.AspNetCore.Authorization;

namespace QuotionSystemSolution.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {

            _projectService = projectService;
        }

        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<List<ResponseProject>>>> GetProjects()
        {
            

            return Ok(await _projectService.GetProjects());
        }
        [HttpGet]

        public async Task<ActionResult<ResponseProject>> GetProjectById(Guid projectId)
        {

            return Ok(await _projectService.GetProjectById(projectId));
        }

        [HttpPost]
        public async Task<ActionResult<ResponseProject>> PostProjects(CreateProject project)
        {
            return Ok(await _projectService.Add(project));
        }


    }
}
