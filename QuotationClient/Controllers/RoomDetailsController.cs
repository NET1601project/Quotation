﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Application;
using Domain;

namespace QuotationClient.Controllers
{
    public class RoomDetailsController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            return View();

        }

        public IActionResult Create(Guid? id)
        {
            return View();
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            return View();

        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            return View();

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            return View();

        }


    }
}
