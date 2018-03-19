using System;
using System.Collections.Generic;
using System.Text;

namespace ESIRT.Core
{
    public class SiteRepository : ISiteRepository
    {
        public void CreateSite(CreateSiteCommand createSiteCommand)
        {
            var site = new Site(createSiteCommand.Data);


            
        }
    }
}
