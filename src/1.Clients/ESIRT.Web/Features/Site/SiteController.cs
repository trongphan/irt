using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESIRT.Web.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ESIRT.Web.Features.Site
{
    public class SiteController : Controller
    {
        readonly IMediator _mediator;
        readonly ApplicationDbContext _db;

        public SiteController(IMediator mediator, ApplicationDbContext db)
        {
            _mediator = mediator;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var oldSite = new ESIRT.Core.NewSite();
            oldSite.Name = "Loaded Site Name";

            return View(oldSite);
        }

        [HttpPost]
        public IActionResult Edit(ESIRT.Core.NewSite newSite)
        {
            var createNewSite = new ESIRT.Core.CreateSiteCommand();
            createNewSite.Data = new Core.NewSite() { Name = newSite.Name };

            var createdSite = _mediator.Send(createNewSite);

            return View(createdSite.Result);
        }

        public void ReRun()
        {
            string json = _db.LoggedEvents.First().Cargo;

            ESIRT.Core.CreateSiteCommand cmd = JsonConvert.DeserializeObject<ESIRT.Core.CreateSiteCommand>(json);
            _mediator.Send(cmd);

        }
    }
}