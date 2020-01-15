using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DatabaseContext : DbContext
{
    public DbSet<ProductionResponse> ProductionResponse { get; set; }
    public DbSet<ProductionSegmentResponse> ProductionSegmentResponse { get; set; }
    public DatabaseContext()
        : base("defaultCon")
    {

    }
}
