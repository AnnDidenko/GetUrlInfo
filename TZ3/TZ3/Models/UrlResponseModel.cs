using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace TZ3.Models
{
    public class UrlResponseModel
    {
        public string Url { get; set; }
        public string Title { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public UrlResponseModel(string url, string title, HttpStatusCode code)
        {
            Url = url;
            Title = title;
            StatusCode = code;
        }
    }
}
