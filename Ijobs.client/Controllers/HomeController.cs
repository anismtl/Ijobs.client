using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ijobs.client.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace Ijobs.client.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["ListeJobs"] = null;
            return View();
        }

        public IActionResult Detail(string id)
        {
            Jobs j = new Jobs();

          
            return View("single",j);
        }



        public async Task<IActionResult> Recherche(string titre, string location)
        {
            List<Jobs> reservationList = new List<Jobs>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://aniss.ca/WebServiceV7/webresources/jobs/search/"+titre+"/"+location+""))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    reservationList = JsonConvert.DeserializeObject<List<Jobs>>(apiResponse);
                }
            } 
            ViewData["ListeJobs"] = reservationList;
            return View("index");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        private static async Task<List<Offre>> getJobs(string emploie)
        {

            string response = null;

            using (var client = new HttpClient())
            {
                var uri = new Uri("http://aniss.ca/WebServiceV7/webresources/jobs/search/java/montreal");
            
                response = await client.GetStringAsync(uri);
            }

            List<Offre> list = JsonConvert.DeserializeObject<List<Offre>>(response);

            return list;
        }

    }
}
