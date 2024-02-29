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
    public class MaterialsController : ControllerBase
    {

        private IMaterialService _materialService;

        public MaterialsController(IMaterialService materialService)
        {
            _materialService = materialService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseMaterial>>> GetMaterials()
        {
            return Ok(await _materialService.GetMaterial());
        }

        //[HttpGet]
        //public async Task<ActionResult<Material>> GetMaterial(Guid id)
        //{

        //}

        //[HttpPut]
        //public async Task<IActionResult> PutMaterial(Guid id, Material material)
        //{
        //    return NoContent();
        //}

        [HttpPost]
        public async Task<ActionResult<ResponseMaterial>> PostMaterials(CreateMaterial material)
        {
            return Ok(await _materialService.Add(material));
        }



    }
}
