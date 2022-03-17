using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Luski_Server_Status
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Luski Status";
            return View();
        }

        [HttpGet]
        [Route("GetCurrentRaw")]
        public ALL GetCurrentRaw()
        {
            return new ALL();
        }

        public class API
        {
            public API(string url)
            {
                using HttpClient web = new();
                HttpResponseMessage? WebResult = web.GetAsync(url).Result;
                if (!WebResult.IsSuccessStatusCode) v1 = new Version();
                else v1 = JsonSerializer.Deserialize<ServerResult>(WebResult.Content.ReadAsStringAsync().Result)?.api.v1;
            }
            public API()
            {

            }

            public Version v1 { get; set; } = default!;
        }

        public class ServerResult
        {
            public API api { get; set; } = default!;
        }

        public class Version
        {
            public Version(string http = "offline", string wss = "offline")
            {
                this.http = http;
                this.wss = wss;
            }

            public string http { get; set; } = default!;
            public string wss { get; set; } = default!;
        }

        public class ALL
        {
            public API Dev { get; } = new API("https://api.dev.luski.jacobtech.com/status");
            public API Beta { get; } = new API("https://api.beta.luski.jacobtech.com/status");
            public API Master { get; } = new API("https://api.master.luski.jacobtech.com/status");
        }
    }
}
