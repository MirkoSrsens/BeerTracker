using System;
using System.ComponentModel.DataAnnotations;

public class ProductionSegmentResponse
{
    [Key]
    public long Oid { get; set; }

    public string ErrorMessage { get; set; }

    public DateTime DateRecieved { get; set; }

    public int Temperature { get; set; }

    public ProductionResponse ProductionResponseModel { get; set; }
}
