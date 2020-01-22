using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kernel.Database
{
    public class HasId : HasOid, IHasId
    {
        public string Id { get; set; }
    }
}
