using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESIRT.Web.Models
{
    public class Index
    {
        public class Query : IRequest<string>
        {
            public string Name { get; set; }
        }

        public class Handler : AsyncRequestHandler<Query, string>
        {
            protected override Task<string> HandleCore(Query request)
            {
                return  Task.FromResult(request.Name);
            }
        }
    }
}
