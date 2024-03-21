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

namespace QuotionSystemSolution.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoomDetailsController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomDetailsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<RoomDetail>>> GetRoomDetails()
        //{

        //}

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

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteRoomDetail(Guid id)
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

        //    _context.RoomDetails.Remove(roomDetail);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

       
    }
}
