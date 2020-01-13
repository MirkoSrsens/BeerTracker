using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebHost.Models;

namespace WebHost.Data
{
    public class DbEntities : DbContext
    {
        public DbEntities() : base(nameOrConnectionString: "BeerDBconn") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
        }

        public DbSet<ProductionSegmentResponseModel> ProductionSegmentResponseModels { get; set; }
        public DbSet<ProductionResponseModel> ProductionResponseModels { get; set; }
    }
}