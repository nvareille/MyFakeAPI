using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFakeAPI.Filters;
using MyFakeAPI.Logic;
using MyFakeAPI.Services;
using Newtonsoft.Json;

namespace MyFakeAPI.Controllers
{
    public class MockController : Controller
    {
        private SeedingService SeedingService;
        
        public MockController(SeedingService seeding)
        {
            SeedingService = seeding;
        }
        
        public IActionResult Index()
        {
            int count = 0;
            string path = HttpContext.Request.Path.ToString().Substring(1);
            string str = System.IO.File.ReadAllText("seeds/" + path + ".json");
            Dictionary<string, string> model = JsonConvert.DeserializeObject<Dictionary<string, string>>(str);
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            ValueGenerator generator = new ValueGenerator(model);
            
            while (count < 50)
            {
                list.Add(generator.GenerateEntity());
                ++count;
            }
            
            return (Json(list));
        }

    }
}
