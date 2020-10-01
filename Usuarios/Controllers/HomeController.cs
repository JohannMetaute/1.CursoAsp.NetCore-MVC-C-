using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Usuarios.Models;
using Microsoft.AspNetCore.Diagnostics;

namespace Usuarios.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //throw new Exception("This is some exception!!");

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int? statusCode = null)
        {
            ErrorViewModel error = null;
            if (statusCode != null)
            {
                error = new ErrorViewModel
                {
                    RequestId = Convert.ToString(statusCode),
                    ErrorMessage="Se produjo en error al procesar su solicitud",
                };
            }
            else
            {
                var exceptionFeatures = HttpContext.Features.Get<IExceptionHandlerFeature>();
                if (exceptionFeatures != null)
                {
                    error = new ErrorViewModel
                    {
                        RequestId = "500",
                        ErrorMessage = exceptionFeatures.Error.Message,
                    };
                }
            }
            return View(error);
            //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
