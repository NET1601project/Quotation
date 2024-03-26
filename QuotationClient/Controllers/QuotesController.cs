using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Application;
using Domain;
using System.Text.Json;
using System.Net.Http.Headers;
using Infrastructure.Common.Model.Response;

namespace QuotationClient.Controllers
{
    public class QuotesController : Controller
    {
        private readonly HttpClient client = null;

        public QuotesController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            return View(id);
        }

        public async Task<IActionResult> CreateAsync()
        {
            await LoadMaterial();
            return View();
        }


        public async Task<IActionResult> Edit(Guid? quouteId)
        {
            return View();
        }


        // GET: Accounts/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            return View();
        }

        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            return View();
        }
        private async Task LoadMaterial()
        {

            HttpResponseMessage roomResponse = await client.GetAsync("https://localhost:7222/api/Materials/GetMaterialsWithGTStock0");
            string roomData = await roomResponse.Content.ReadAsStringAsync();

            var roomOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            List<ResponseMaterial> materials = JsonSerializer.Deserialize<List<ResponseMaterial>>(roomData, roomOptions);

            ViewData["MaterialID"] = new SelectList(materials.Select(c => new
            {
                Text = $"Name: {c.MaterialName} - UnitPrice: {c.UnitPrice} - Stock: {c.Stock}",
                Value = c.MaterialID
            }), "Value", "Text");

        }
    }
}
