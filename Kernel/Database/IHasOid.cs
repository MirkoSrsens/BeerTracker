﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kernel.Database
{
    public interface IHasOid
    {
        long Oid { get; set; }
    }
}
