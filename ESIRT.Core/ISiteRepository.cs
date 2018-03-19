using System;
using System.Collections.Generic;
using System.Text;

namespace ESIRT.Core
{
    public interface ISiteRepository
    {
        void CreateSite(CreateSiteCommand createSiteCommand);
    }
}
