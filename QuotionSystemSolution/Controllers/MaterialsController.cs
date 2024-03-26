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
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;

namespace QuotionSystemSolution.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MaterialsController : ODataController
    {

        private IMaterialService _materialService;

        public MaterialsController(IMaterialService materialService)
        {
            _materialService = materialService;
        }

        [HttpGet]
        [EnableQuery]

        public async Task<ActionResult<IEnumerable<ResponseMaterial>>> GetMaterials()
        {
            return Ok(await _materialService.GetMaterial());
        }

        [HttpGet]
        public async Task<ActionResult<ResponseMaterial>> GetMaterialById(Guid id)
        {
            return Ok(await _materialService.GetMaterialById(id));

        }
        [HttpGet]
        public async Task<ActionResult<ResponseMaterial>> GetMaterialsWithGTStock0()
        {
            return Ok(await _materialService.GetMaterialsWithGTStock0());

        }


        [HttpPost]
        public async Task<ActionResult<ResponseMaterial>> PostMaterials([FromForm] CreateMaterial material)
        {
            return Ok(await _materialService.Add(material));
        }
        [HttpPut]
        public async Task<ActionResult<ResponseMaterial>> PutMaterial(Guid id, [FromForm] CreateMaterial createMaterial)
        {
            return Ok(await _materialService.Edit(id, createMaterial));
        }
    }
}
