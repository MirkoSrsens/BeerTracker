using Kernel.Database;
using System;
using System.ComponentModel.DataAnnotations;


namespace DatabaseModels
{
    public class ProductionSegmentResponse : HasId
    {
        public string ErrorMessage { get; set; }
        public DateTime DateRecieved { get; set; }
        public int Temperature { get; set; }
        public ProductionResponse ProductionResponseModel { get; set; }
    }
}