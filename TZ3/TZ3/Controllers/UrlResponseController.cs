using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TZ3.Models;

namespace TZ3.Controllers
{
    public class UrlResponseController : Controller
    {
        [HttpGet()]
        public async Task<IActionResult> Index([FromQuery] string url)
        {
            if (url == "https://brights.io/")
            {
                await Task.Delay(2000);
            }
            var client = new RestClient(url);
            client.Timeout = -1;

            var request = new RestRequest(Method.GET);
            request.AddHeader("Cookie", "_rl=1");

            var response = client.Execute(request);

            var pattern = @"<title>.*</title>";
            var match = Regex.Match(response.Content, pattern).ToString();

            pattern = @"(<title>)|(</title>)";
            var title = Regex.Replace(match, pattern, string.Empty).ToString();

            var urlResponse = new UrlResponseModel(url, title, response.StatusCode);

            return Ok(urlResponse);
        }
    }
}
