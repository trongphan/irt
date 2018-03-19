
using System;
using System.Collections.Generic;
using System.Text;

namespace ESIRT.Core
{
    public class LoggedEvent
    {
        public int Id { get; set; }
        public string Action { get; set; }
        public int AggregateId { get; set; }
        public string Cargo { get; set; }
    }
}
