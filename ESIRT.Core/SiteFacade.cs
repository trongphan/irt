using System;
using System.Collections.Generic;
using System.Text;

namespace ESIRT.Core
{
    public class SiteFacade : ISiteFacade
    {
        ISiteRepository _siteRepository;
        public SiteFacade(ISiteRepository siteRepository)
        {
            _siteRepository = siteRepository;
        }

        public void CreateNewSite(CreateSiteCommand createSiteCommand)
        {
            
            


          
        }

        public void UpdateSite(Site site)
        {
            throw new NotImplementedException();
        }
    }
}
