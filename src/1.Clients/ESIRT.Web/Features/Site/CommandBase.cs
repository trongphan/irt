using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ESIRT.Core
{
    public class CommandBase
    {
        public string Action { get; set; }
        public DateTime CreatedDatetime { get; set; }
        public int RequestId { get; set; }

        public LoggedEvent ToEvent(int aggregateId)
        {
            var cargo = JsonConvert.SerializeObject(this);
            return new LoggedEvent() { Action = this.Action, AggregateId = aggregateId, Cargo = cargo };
        }
    }
}
