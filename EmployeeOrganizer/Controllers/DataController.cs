using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using EmployeeOrganizer.Models;

namespace EmployeeOrganizer.Controllers
{
    public class DataController : Controller
    {
        AppDbContext _ctx;
        public DataController(AppDbContext context)
        {
            _ctx = context;
        }
        public async Task<IActionResult> Index()
        {
            UtilityModel util = new UtilityModel(_ctx);
            var json = await getWorkersJsonFromWebAsync();
            try
            {
                ViewBag.LoadedMsg = (util.loadWorkerTables(json)) ? "Worker Type and Worker tables loaded" : "problem loading tables";
            }
            catch (Exception ex)
            {
                ViewBag.LoadedMsg = ex.Message;
            }
            return View("Index");
        }

        private async Task<String> getWorkersJsonFromWebAsync()
        {
            string url = "https://raw.githubusercontent.com/BobEh/testingStyles/master/WorkerJson.json";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }
    }
}
