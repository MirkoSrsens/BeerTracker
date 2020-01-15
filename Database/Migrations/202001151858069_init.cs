namespace DatabaseManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductionResponses",
                c => new
                    {
                        Oid = c.Long(nullable: false, identity: true),
                        EquipmentId = c.String(),
                        StartTime = c.DateTime(nullable: false),
                        ExpectedEndTime = c.DateTime(nullable: false),
                        BeerInProduction = c.String(),
                    })
                .PrimaryKey(t => t.Oid);
            
            CreateTable(
                "dbo.ProductionSegmentResponses",
                c => new
                    {
                        Oid = c.Long(nullable: false, identity: true),
                        ErrorMessage = c.String(),
                        DateRecieved = c.DateTime(nullable: false),
                        Temperature = c.Int(nullable: false),
                        ProductionResponseModel_Oid = c.Long(),
                    })
                .PrimaryKey(t => t.Oid)
                .ForeignKey("dbo.ProductionResponses", t => t.ProductionResponseModel_Oid)
                .Index(t => t.ProductionResponseModel_Oid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductionSegmentResponses", "ProductionResponseModel_Oid", "dbo.ProductionResponses");
            DropIndex("dbo.ProductionSegmentResponses", new[] { "ProductionResponseModel_Oid" });
            DropTable("dbo.ProductionSegmentResponses");
            DropTable("dbo.ProductionResponses");
        }
    }
}
