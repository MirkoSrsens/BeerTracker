using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class ProductionResponse
    {
        [Key]
        public long Oid { get; set; }
        public string EquipmentId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime ExpectedEndTime { get; set; }
        public string BeerInProduction { get; set; }
        public List<ProductionSegmentResponse> ProductionSegmentResponses { get; set; }
    }
