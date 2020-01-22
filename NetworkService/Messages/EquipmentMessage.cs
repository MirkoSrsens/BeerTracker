using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkService.Messages
{
    [Serializable]
    public class EquipmentMessage
    {
        public string Id { get; set; }
        public string State { get; set; }
        public int CurrentCapacity { get; set; }
        public int MaxCapacity { get; set; }
        public DateTime? LastInspectionDate { get; set; }
    }
}
