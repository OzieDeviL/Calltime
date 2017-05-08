using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Calltime.Web.Domain
{
    public class ProductionBase: DomainBase, IDomain
    {
        public string ProductionName { get; set; }
        public string LongName { get; set; }
        public string CodeName { get; set; }
    }
}