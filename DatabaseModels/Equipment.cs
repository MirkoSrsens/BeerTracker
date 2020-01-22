using Kernel.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatabaseModels
{
    public class Equipment : HasId
    {
        public string State { get; set; }
        public int CurrentCapacity { get; set; }
        public int MaxCapacity { get; set; }
        public DateTime? LastInspectionDate { get; set; }
        public List<ProductionResponse> ProductionResponses { get; set; }
    }
}
