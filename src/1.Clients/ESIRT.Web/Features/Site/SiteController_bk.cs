using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using FluentValidation.Attributes;
using FluentValidation.Results;
using FluentValidation.AspNetCore;
using Newtonsoft.Json;
using ESIRT.Core;
using ESIRT.Web.Data;

namespace ESIRT.Web.Features.Site
{
    public class SiteController_bk : Controller
    {
        readonly IMediator _mediator;
        public SiteController_bk(IMediator mediator) => _mediator = mediator;

        public IActionResult Index()
        {

            var createNewSiteCmd = new ESIRT.Core.CreateSiteCommand();

            createNewSiteCmd.RequestId = 1;
            

            createNewSiteCmd.Data = new Core.NewSite();

            createNewSiteCmd.Data.Name = "Site Name";


            var test = _mediator.Send(createNewSiteCmd);


            var cmd = new Query();

            var ret = _mediator.Send(cmd);
            var cust = ret.Result;


            return View(createNewSiteCmd.Data);
        }

        [HttpGet]
        [Route("site/edit/{id}")]
        public IActionResult Edit(int id)
        {
            var newSite = new NewSite();
            newSite.Name = "df";

            return View(newSite);

            // var cust = new Customer();
            // return View(cust);
        }

        [HttpPost]
        [Route("site/edit/{id}")]
        public IActionResult Edit(NewSite newSite)
        {
            var cmd = new EditQuery();
            var model = _mediator.Send(cmd);

            // ModelState.AddModelError(string.Empty, "Student Name already exists.");
            // ModelState.AddModelError()

            // var val = new CustomerValidator();
            //var ret = val.Validate(cust);




            //foreach (ValidationFailure failer in ret.Errors)
            //{
            //    ModelState.AddModelError(failer.PropertyName, failer.ErrorMessage);

            //}

            //ret.AddToModelState(ModelState, "Customer");



            //IEnumerable<KeyValuePair<string, string[]>> errors = ModelState.IsValid? null
            //                        : ModelState
            //                        .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray())

            //                        .Where(m => m.Value.Any());




            //string content = JsonConvert.SerializeObject(ModelState,
            //        new JsonSerializerSettings
            //        {
            //            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            //        });

            //string content1 = JsonConvert.SerializeObject(errors);


            //model binder - for POST will use attemptvalue ralther rawvalue
            //ModelState.Clear();
            //newSite.Name = "TP Edited.";

            //return View(newSite);

            var createNewSite = new ESIRT.Core.CreateSiteCommand();
            createNewSite.Data = new Core.NewSite() { Name = newSite.Name, CreatedBy = 1 };

            var createdSite = _mediator.Send(createNewSite);

            return View(newSite);
        }

        public class EditQuery : IRequest<Customer>
        {
            public int Id { get; set; }
        }

        public class EditHandler : AsyncRequestHandler<EditQuery, Customer>
        {
            private readonly ApplicationDbContext _db;
            public EditHandler(ApplicationDbContext db) => _db = db;
            
            protected override Task<Customer> HandleCore(EditQuery request)
            {
                var cust = new Customer();
                cust.Id = 1;
                cust.Name = "Editing";
                cust.NameTP = "Hello";

                return Task.FromResult(cust);
            }
        }



        public class Customer
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public string NameTP { get; set; }
        }


        public class CustomerValidator : AbstractValidator<Customer>
        {
            public CustomerValidator()
            {
                RuleFor(m => m.Id).NotNull();
                RuleFor(m => m.Name).NotNull().WithMessage("not null").MaximumLength(2).WithMessage("TP");

                RuleFor(m => m.Name).Equal("TP").WithMessage("Not equal to TP");

                RuleFor(m => m.NameTP).NotNull().WithMessage("not null").MinimumLength(2).WithMessage("NameTP");
            }
        }


        public class Query : IRequest<Customer>
        {

        }

        public class Handler : AsyncRequestHandler<Query, Customer>
        {
            protected override Task<Customer> HandleCore(Query request)
            {
                var cust = new Customer();
                cust.Id = 1;
                cust.Name = "TP";

                return Task.FromResult(cust);
            }
        }
    }
}