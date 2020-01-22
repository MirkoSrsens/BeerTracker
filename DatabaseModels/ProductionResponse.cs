using Kernel.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatabaseModels
{
    public class ProductionResponse : HasId
    {
        public string EquipmentId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime ExpectedEndTime { get; set; }
        public string BeerInProduction { get; set; }
        public Equipment Equipment { get; set; }
        public List<ProductionSegmentResponse> ProductionSegmentResponses { get; set; }
    }
}
