using CompleteUserInterface.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CompleteUserInterface.Controllers
{
    public class ProductController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public ProductController(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        // GET: ProductController
        public async Task<IActionResult> Index()
        {
            _httpClient.BaseAddress = new Uri(_configuration["Host"]+"product");
            var response = await _httpClient.GetAsync("");
            var body = await response.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<List<Product>>(body);
            return View(model);
        }


        // GET: ProductController/Details
        [Route("Details")]
        public async Task<ActionResult> Details(Product product)
        {
            _httpClient.BaseAddress = new Uri(_configuration["Host"] + "product" + product.ProductId);
            var response = await _httpClient.GetAsync("");
            var body = await response.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<List<Product>>(body);
            return View(model);
        }

        // GET: ProductController/Create
        [Route("Create")]
        public ActionResult Create()
        {
            return View(new Product());
        }

        // POST: ProductController/Create
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> Create(Product product)
        {
            try
            {
                var json = JsonConvert.SerializeObject(product);
                _httpClient.BaseAddress = new Uri(_configuration["Host"] + "product");
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("", content);
                return RedirectToAction("index");
            }
            catch
            {
                return View();
            }
        }

        [Route("Edit")]
        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [Route("Edit")]
        public async Task<ActionResult> Edit(Product product)
        {
            try
            {
                var json = JsonConvert.SerializeObject(product);
                _httpClient.BaseAddress = new Uri(_configuration["InventoryUpUrl"]);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync(product.ProductId.ToString(), content);
                return RedirectToAction("index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        [Route("Delete")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [Route("Delete")]
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
