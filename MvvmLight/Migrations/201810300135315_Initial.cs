namespace MvvmLight.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Patient",
                c => new
                    {
                        PatientId = c.Long(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(),
                        DateOfBirth = c.DateTime(),
                    })
                .PrimaryKey(t => t.PatientId);
            
            CreateTable(
                "dbo.Record",
                c => new
                    {
                        StatusOfRecord = c.String(nullable: false, maxLength: 8000, unicode: false),
                        RecordId = c.Long(nullable: false, identity: true),
                        RecordStatusRange = c.Int(),
                        PatientId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.RecordId)
                .ForeignKey("dbo.Patient", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Record", "PatientId", "dbo.Patient");
            DropIndex("dbo.Record", new[] { "PatientId" });
            DropTable("dbo.Record");
            DropTable("dbo.Patient");
        }
    }
}
