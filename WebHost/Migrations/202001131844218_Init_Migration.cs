namespace WebHost.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init_Migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.ProductionResponseModels",
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
                "public.ProductionSegmentResponseModels",
                c => new
                    {
                        oid = c.Long(nullable: false, identity: true),
                        errorMessage = c.String(),
                        dateRecieved = c.DateTime(nullable: false),
                        temperature = c.Int(nullable: false),
                        ProductionResponseModel_oid = c.Long(),
                    })
                .PrimaryKey(t => t.oid)
                .ForeignKey("public.ProductionResponseModels", t => t.ProductionResponseModel_oid)
                .Index(t => t.ProductionResponseModel_oid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("public.ProductionSegmentResponseModels", "ProductionResponseModel_oid", "public.ProductionResponseModels");
            DropIndex("public.ProductionSegmentResponseModels", new[] { "ProductionResponseModel_oid" });
            DropTable("public.ProductionSegmentResponseModels");
            DropTable("public.ProductionResponseModels");
        }
    }
}
