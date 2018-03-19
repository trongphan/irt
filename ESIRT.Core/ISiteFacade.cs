using System;
using System.Collections.Generic;
using System.Text;

namespace ESIRT.Core
{
    public interface ISiteFacade
    {
        void CreateNewSite(CreateSiteCommand createSiteCommand);
        void UpdateSite(Site site);
    }
}
