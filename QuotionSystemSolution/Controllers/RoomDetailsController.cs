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
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace QuotionSystemSolution.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoomDetailsController : ODataController
    {
        private readonly IRoomService _roomService;

        public RoomDetailsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomDetail>>> GetRoomDetails()
        {
            return Ok(await _roomService.GetAll());

        }

        //[HttpGet]
        //public async Task<ActionResult<RoomDetail>> GetRoomDetail(Guid id)
        //{
        //    if (_context.RoomDetails == null)
        //    {
        //        return NotFound();
        //    }
        //    var roomDetail = await _context.RoomDetails.FindAsync(id);

        //    if (roomDetail == null)
        //    {
        //        return NotFound();
        //    }

        //    return roomDetail;
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutRoomDetail(Guid id, RoomDetail roomDetail)
        //{

        //}

        [HttpPost]
        public async Task<ActionResult<RoomDetail>> PostRoomDetail(CreateRoomDetailV2 roomDetail)
        {
            return Ok(await _roomService.PostRoomDetail(roomDetail));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRoomDetail(Guid id)
        {
            return Ok(await _roomService.RemoveDetailRoom(id));

        }


    }
}
