using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ESIRT.Web.Models;
using MediatR;

namespace ESIRT.Web.Controllers
{
    public class HomeController_ : Controller
    {
        private readonly IMediator _mediator;

        public HomeController_(IMediator mediator) => _mediator = mediator;
        

        public IActionResult Index()
        {
            var cmd = new Models.Index.Query();
            cmd.Name = "Hello!";
            var test =  _mediator.Send<string>(cmd);
            
            return View();

        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
