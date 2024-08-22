using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Lab6Client.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Net;

namespace Lab6.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly string _serviceUrl;

        public HomeController(IConfiguration config)
        {
            _configuration = config;
            _serviceUrl = _configuration.GetValue<string>("ServerURL");
        }

        // GET: Home/Index
        public async Task<IActionResult> Index()
        {
            List<RestaurantInfo> restaurants = new List<RestaurantInfo>();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"{_serviceUrl}/RestaurantReview");
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    restaurants = JsonSerializer.Deserialize<List<RestaurantInfo>>(data);
                }
            }

            return View(restaurants);
        }

        // GET: Home/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RestaurantInfo restaurant = null;
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"{_serviceUrl}/RestaurantReview/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    restaurant = JsonSerializer.Deserialize<RestaurantInfo>(data);
                }
            }

            if (restaurant == null)
            {
                return NotFound();
            }

            return View(restaurant);
        }

        // POST: Home/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(RestaurantInfo restInfo)
        {
            if (!ModelState.IsValid)
            {
                return View(restInfo);
            }

            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(JsonSerializer.Serialize(restInfo), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync($"{_serviceUrl}/RestaurantReview", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(restInfo);
        }

        // GET: Home/New
        public IActionResult New()
        {
            return View();
        }

        // POST: Home/New
        [HttpPost]
        public async Task<IActionResult> New(RestaurantInfo restInfo)
        {
            if (!ModelState.IsValid)
            {
                return View(restInfo);
            }

            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(JsonSerializer.Serialize(restInfo), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync($"{_serviceUrl}/RestaurantReview", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(restInfo);
        }

        // GET: Home/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.DeleteAsync($"{_serviceUrl}/RestaurantReview/{id}");
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return NotFound();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}