namespace MvvmLight.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommentMapKey : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Record", new[] { "PatientId" });
            DropIndex("dbo.Record", new[] { "Patient_PatientId1" });
            RenameColumn(table: "dbo.Record", name: "Patient_PatientId1", newName: "Patient_PatientId");
            RenameColumn(table: "dbo.Record", name: "PatientId", newName: "Patient_PatientId");
            AlterColumn("dbo.Record", "Patient_PatientId", c => c.Long());
            CreateIndex("dbo.Record", "Patient_PatientId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Record", new[] { "Patient_PatientId" });
            AlterColumn("dbo.Record", "Patient_PatientId", c => c.Long(nullable: false));
            RenameColumn(table: "dbo.Record", name: "Patient_PatientId", newName: "PatientId");
            RenameColumn(table: "dbo.Record", name: "Patient_PatientId", newName: "Patient_PatientId1");
            CreateIndex("dbo.Record", "Patient_PatientId1");
            CreateIndex("dbo.Record", "PatientId");
        }
    }
}
