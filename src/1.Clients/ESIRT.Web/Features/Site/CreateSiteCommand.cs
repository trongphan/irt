using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ESIRT.Web.Data;

namespace ESIRT.Core
{
    public class CreateSiteCommand : CommandBase, IRequest<NewSite>
    {
        public NewSite Data { get; set; }
        
        public CreateSiteCommand()
        {
            Action = this.GetType().ToString();
            CreatedDatetime = DateTime.UtcNow;
        }       
    }

    public class CreateSiteCommandHandler : AsyncRequestHandler<CreateSiteCommand, NewSite>
    {        
        readonly ApplicationDbContext _db;
        public CreateSiteCommandHandler(ApplicationDbContext db) => _db = db;
       
        protected override Task<NewSite> HandleCore(CreateSiteCommand request)
        {
            //var siteFacade = new ESIRT.Core.SiteFacade(new ESIRT.Core.SiteRepository());
            //siteFacade.CreateNewSite(request);
            
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    var newSite = new ESIRT.Core.Site(request.Data);

                    _db.Sites.Add(newSite);
                    _db.SaveChanges();

                    var eventTolog = request.ToEvent(newSite.Id);
                    _db.LoggedEvents.Add(eventTolog);
                    _db.SaveChanges();

                    // Commit transaction if all commands succeed, transaction will auto-rollback
                    // when disposed if either commands fails
                    transaction.Commit();
                }
                catch (Exception)
                {
                    // TODO: Handle failure
                }
            }

            return Task.FromResult(request.Data);
        }
    }
}
