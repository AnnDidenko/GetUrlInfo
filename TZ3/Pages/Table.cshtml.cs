using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestSharp;

namespace TZ3.Pages
{
    public class TableModel : PageModel
    {
        public string Input { get; set; }
        public string Message { get; set; }
        public void OnGet(string input)
        {
            Input = input;
        }


        public void OnPost(string url, string content, HttpStatusCode code)
        {
        }
    }
}
