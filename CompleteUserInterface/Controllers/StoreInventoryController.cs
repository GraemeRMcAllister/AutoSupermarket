using CompleteUserInterface.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CompleteUserInterface.Controllers
{
    public class StoreInventoryController : Controller
    {

        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;


        public StoreInventoryController(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }



        // GET: StoreInventory
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            _httpClient.BaseAddress = new Uri(_configuration["Host"] + "storeinventory");
            var response = await _httpClient.GetAsync("");
            var responebody = await response.Content.ReadAsStringAsync();
            var models = JsonConvert.DeserializeObject<List<StockItem>>(responebody);
            return View(models);
        }
        // GET: StoreInventoryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [Route("Alert")]
        public async Task<ActionResult> Alert()
        {
            _httpClient.BaseAddress = new Uri(_configuration["Host"] + "storeinventory");
            var response = await _httpClient.GetAsync("");
            var body = await response.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<List<StockItem>>(body);
            return View(model);
        }

        // GET: StoreInventoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StoreInventoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StoreInventoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StoreInventoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StoreInventoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StoreInventoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
