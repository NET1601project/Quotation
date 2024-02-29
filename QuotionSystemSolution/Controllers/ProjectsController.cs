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
        public async Task<ActionResult<IEnumerable<List<ResponseProject>>>> GetProjects()
        {
            return Ok(await _projectService.GetProjects());
        }



        [HttpPost]
        public async Task<ActionResult<Project>> PostProject(CreateProject project)
        {
            return Ok(await _projectService.Add(project));
        }


    }
}
