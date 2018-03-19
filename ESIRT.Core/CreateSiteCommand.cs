using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

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
        
        public CreateSiteCommandHandler()
        {

        }
        protected override Task<NewSite> HandleCore(CreateSiteCommand request)
        {
            var siteFacade = new ESIRT.Core.SiteFacade(new ESIRT.Core.SiteRepository());
            siteFacade.CreateNewSite(request);

            var eventTolog = request.ToEvent(5);
            return Task.FromResult(request.Data);
        }
    }
}
