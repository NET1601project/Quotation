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
    public class RoomsController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }
        [HttpGet]
        public async Task<ActionResult<ResponseRoomV2>> GetRooms()
        {
            return Ok(await _roomService.GetAll());
        }
        [HttpGet]
        public async Task<ActionResult<ResponseRoomV2>> GetRoomByID(Guid id)
        {
            return Ok(await _roomService.GetById(id));
        }
        [HttpPatch]
        public async Task<ActionResult<ResponseRoomV2>> PatchRoom(Guid id, CreateRoom room)
        {
            return Ok(await _roomService.Edit(id, room));
        }

        [HttpPatch]
        public async Task<ActionResult<ResponseRoomDetail>> PatchRoomDetails(Guid id, CreateRoomDetail room)
        {
            return Ok(await _roomService.EditDetail(id, room));
        }
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<ResponseRoomDetail>>> GetRoomByCustomer()
        {
            return Ok(await _roomService.GetRoomByCustomer());
        }
    }
}
