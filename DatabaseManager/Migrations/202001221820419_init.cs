namespace DatabaseManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Equipments",
                c => new
                    {
                        Oid = c.Long(nullable: false, identity: true),
                        State = c.String(),
                        CurrentCapacity = c.Int(nullable: false),
                        MaxCapacity = c.Int(nullable: false),
                        LastInspectionDate = c.DateTime(),
                        Id = c.String(),
                    })
                .PrimaryKey(t => t.Oid);
            
            CreateTable(
                "dbo.ProductionResponses",
                c => new
                    {
                        Oid = c.Long(nullable: false, identity: true),
                        EquipmentId = c.String(),
                        StartTime = c.DateTime(nullable: false),
                        ExpectedEndTime = c.DateTime(nullable: false),
                        BeerInProduction = c.String(),
                        Id = c.String(),
                        Equipment_Oid = c.Long(),
                    })
                .PrimaryKey(t => t.Oid)
                .ForeignKey("dbo.Equipments", t => t.Equipment_Oid)
                .Index(t => t.Equipment_Oid);
            
            CreateTable(
                "dbo.ProductionSegmentResponses",
                c => new
                    {
                        Oid = c.Long(nullable: false, identity: true),
                        ErrorMessage = c.String(),
                        DateRecieved = c.DateTime(nullable: false),
                        Temperature = c.Int(nullable: false),
                        Id = c.String(),
                        ProductionResponseModel_Oid = c.Long(),
                    })
                .PrimaryKey(t => t.Oid)
                .ForeignKey("dbo.ProductionResponses", t => t.ProductionResponseModel_Oid)
                .Index(t => t.ProductionResponseModel_Oid);
            
            CreateTable(
                "dbo.NotificationMessages",
                c => new
                    {
                        Oid = c.Long(nullable: false, identity: true),
                        ErrorCode = c.String(),
                    })
                .PrimaryKey(t => t.Oid);
            
            CreateTable(
                "dbo.NotificationMessageUsers",
                c => new
                    {
                        Oid = c.Long(nullable: false, identity: true),
                        NotificationMessage_Oid = c.Long(),
                        NotificationUser_Oid = c.Long(),
                    })
                .PrimaryKey(t => t.Oid)
                .ForeignKey("dbo.NotificationMessages", t => t.NotificationMessage_Oid)
                .ForeignKey("dbo.NotificationUsers", t => t.NotificationUser_Oid)
                .Index(t => t.NotificationMessage_Oid)
                .Index(t => t.NotificationUser_Oid);
            
            CreateTable(
                "dbo.NotificationUsers",
                c => new
                    {
                        Oid = c.Long(nullable: false, identity: true),
                        Email = c.String(),
                        Id = c.String(),
                    })
                .PrimaryKey(t => t.Oid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NotificationMessageUsers", "NotificationUser_Oid", "dbo.NotificationUsers");
            DropForeignKey("dbo.NotificationMessageUsers", "NotificationMessage_Oid", "dbo.NotificationMessages");
            DropForeignKey("dbo.ProductionSegmentResponses", "ProductionResponseModel_Oid", "dbo.ProductionResponses");
            DropForeignKey("dbo.ProductionResponses", "Equipment_Oid", "dbo.Equipments");
            DropIndex("dbo.NotificationMessageUsers", new[] { "NotificationUser_Oid" });
            DropIndex("dbo.NotificationMessageUsers", new[] { "NotificationMessage_Oid" });
            DropIndex("dbo.ProductionSegmentResponses", new[] { "ProductionResponseModel_Oid" });
            DropIndex("dbo.ProductionResponses", new[] { "Equipment_Oid" });
            DropTable("dbo.NotificationUsers");
            DropTable("dbo.NotificationMessageUsers");
            DropTable("dbo.NotificationMessages");
            DropTable("dbo.ProductionSegmentResponses");
            DropTable("dbo.ProductionResponses");
            DropTable("dbo.Equipments");
        }
    }
}
