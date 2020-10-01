using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Usuarios.Controllers
{
    //[Route("[controller]")]
    public class UsuariosController : Controller
    {
        //[HttpGet]
        //[HttpPost]
        //[Route("/Usuarios/Johann")]
        //[HttpGet("[controller]/[action]/{data:int}")]
        public IActionResult Index(int data)
        {
            //var url = Url.Action("Metodo","Usuarios", new { age=27, name="Johann"});
            //var data = $"Codigo de estado {code}";
            var url = Url.RouteUrl("Metaute", new { age = 27, name = "Johann" });
            return Redirect(url);
        }

        [HttpGet("[controller]/[action]", Name = "Metaute")]
        public IActionResult Metodo(int code)
        {
            var data = $"Codigo de estado {code}";
            //var data = $"Codigo de estado {code}";
            return View("Index", data);
        }
    }
}