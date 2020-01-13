using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebHost.Models
{
    public class EquipmentModel
    {
        public long oid { get; set; }

        public string id { get; set; }

        public string state { get; set; }

        public int currentCapacity { get; set; }

        public int maxCapacity { get; set; }

        public DateTime lastInspectionDate { get; set; }

        public EquipmentModel(long oid, string id)
        {
            this.oid = oid;
            this.id = id;
            this.state = "Ready";
            this.currentCapacity = 500;
            this.maxCapacity = 1500;
            lastInspectionDate = DateTime.Now;
        }
    }
}