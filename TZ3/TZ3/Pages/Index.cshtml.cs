using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TZ3.Pages
{
    public class IndexModel : PageModel
    {
        public string Input { get; set; }
        public string Message { get; set; }
        public void OnGet()
        {
            Message = "Input url";
        }

        public ActionResult OnPost(string input)
        {
            return RedirectToPage("Table", new { Input = input }) ;
        }
    }
}
