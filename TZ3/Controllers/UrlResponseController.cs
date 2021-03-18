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
    [Route("UrlResponse")]
    public class UrlResponseController : Controller
    {
        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index([FromQuery] string url)
        {
            var client = new RestClient(url);

            var request = new RestRequest(Method.GET);

            var response = await client.ExecuteAsync(request);

            var pattern = @"<title>.*</title>";
            var match = Regex.Match(response.Content, pattern);

            pattern = @"(<title>)|(</title>)";
            var title = Regex.Replace(match.Value, pattern, string.Empty);

            var result = new UrlResponseModel
            {
                Url = url,
                Title = title,
                StatusCode = response.StatusCode,
            };

            return Ok(result);
        }
    }
}
