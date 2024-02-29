using Microsoft.AspNetCore.Mvc;
using Domain;
using Infrastructure.Service;
using Infrastructure.Common.Model.Response;
using Infrastructure.Common.Model.Request;

namespace QuotionSystemSolution.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EquipmentsController : ControllerBase
    {
        private readonly IEquipmentService _equipmentService;

        public EquipmentsController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseEquipment>>> GetEquipments()
        {
            return Ok(await _equipmentService.GetEquipment());
        }

        //[HttpGet]
        //public async Task<ActionResult<Equipment>> GetEquipment(Guid id)
        //{

        //}

        //[HttpPut]
        //public async Task<IActionResult> PutEquipment(Guid id, Equipment equipment)
        //{

        //}

        [HttpPost]
        public async Task<ActionResult<ResponseEquipment>> PostEquipments(CreateEquipment equipment)
        {
            return Ok(await _equipmentService.Add(equipment));
        }



    }
}
