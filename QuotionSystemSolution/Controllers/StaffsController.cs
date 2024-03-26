﻿using System;
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
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;

namespace QuotionSystemSolution.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StaffsController : ODataController
    {
        private readonly IStaffService _staffService;

        public StaffsController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpGet]
        [EnableQuery]

        public async Task<ActionResult<List<ResponseStaff>>> GetStaffs()
        {
            return Ok(await _staffService.GetStaff());
        }
        [HttpGet]
        public async Task<ActionResult<List<ResponseStaff>>> GetStaffById(Guid staffId)
        {
            return Ok(await _staffService.GetStaffById(staffId));
        }
        [HttpPost]
        public async Task<ActionResult<ResponseStaff>> PostStaffs(CreateStaff staff)
        {
            return Ok(await _staffService.Add(staff));
        }

        //        // GET: api/Staffs/5
        //        [HttpGet("{id}")]
        //        public async Task<ActionResult<Staff>> GetStaff(Guid id)
        //        {

        //        }

        //        // PUT: api/Staffs/5
        //        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //        [HttpPut("{id}")]
        //        public async Task<IActionResult> PutStaff(Guid id, Staff staff)
        //        {
        //        }
        //        // POST: api/Staffs
        //        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //        [HttpPost]
        //        public async Task<ActionResult<Staff>> PostStaff(Staff staff)
        //        {

        //        }

        //        // DELETE: api/Staffs/5
        //        [HttpDelete("{id}")]
        //        public async Task<IActionResult> DeleteStaff(Guid id)
        //        {

        //        }

        //        private bool StaffExists(Guid id)
        //        {

        //        }

    }
}
