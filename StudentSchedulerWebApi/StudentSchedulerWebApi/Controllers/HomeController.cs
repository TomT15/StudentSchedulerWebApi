using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace StudentSchedulerWebApi.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
