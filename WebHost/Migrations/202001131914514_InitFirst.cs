namespace WebHost.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitFirst : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductionResponseModels",
                c => new
                    {
                        oid = c.Long(nullable: false, identity: true),
                        equipmentId = c.String(),
                        startTime = c.DateTime(nullable: false),
                        expectedEndTime = c.DateTime(nullable: false),
                        beerInProduction = c.String(),
                    })
                .PrimaryKey(t => t.oid);
            
            CreateTable(
                "dbo.ProductionSegmentResponseModels",
                c => new
                    {
                        oid = c.Long(nullable: false, identity: true),
                        errorMessage = c.String(),
                        dateRecieved = c.DateTime(nullable: false),
                        temperature = c.Int(nullable: false),
                        ProductionResponseModel_oid = c.Long(),
                    })
                .PrimaryKey(t => t.oid)
                .ForeignKey("dbo.ProductionResponseModels", t => t.ProductionResponseModel_oid)
                .Index(t => t.ProductionResponseModel_oid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductionSegmentResponseModels", "ProductionResponseModel_oid", "dbo.ProductionResponseModels");
            DropIndex("dbo.ProductionSegmentResponseModels", new[] { "ProductionResponseModel_oid" });
            DropTable("dbo.ProductionSegmentResponseModels");
            DropTable("dbo.ProductionResponseModels");
        }
    }
}
