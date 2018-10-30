namespace MvvmLight.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TryFluentAPI : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Record", "PatientId", "dbo.Patient");
            RenameColumn(table: "dbo.Patient", name: "PatientId", newName: "PATIENT_ID");
            RenameColumn(table: "dbo.Patient", name: "FirstName", newName: "FIRST_NAME");
            RenameColumn(table: "dbo.Patient", name: "LastName", newName: "LAST_NAME");
            RenameColumn(table: "dbo.Patient", name: "DateOfBirth", newName: "DATE_OF_BIRTH");
            RenameColumn(table: "dbo.Record", name: "StatusOfRecord", newName: "RecordStatus");
            AddColumn("dbo.Record", "Patient_PatientId1", c => c.Long());
            AlterColumn("dbo.Patient", "FIRST_NAME", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Patient", "LAST_NAME", c => c.String(maxLength: 50));
            AlterColumn("dbo.Record", "RecordStatus", c => c.String());
            CreateIndex("dbo.Record", "Patient_PatientId1");
            AddForeignKey("dbo.Record", "Patient_PatientId1", "dbo.Patient", "PATIENT_ID");
            AddForeignKey("dbo.Record", "PatientId", "dbo.Patient", "PATIENT_ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Record", "PatientId", "dbo.Patient");
            DropForeignKey("dbo.Record", "Patient_PatientId1", "dbo.Patient");
            DropIndex("dbo.Record", new[] { "Patient_PatientId1" });
            AlterColumn("dbo.Record", "RecordStatus", c => c.String(nullable: false, maxLength: 8000, unicode: false));
            AlterColumn("dbo.Patient", "LAST_NAME", c => c.String());
            AlterColumn("dbo.Patient", "FIRST_NAME", c => c.String(nullable: false));
            DropColumn("dbo.Record", "Patient_PatientId1");
            RenameColumn(table: "dbo.Record", name: "RecordStatus", newName: "StatusOfRecord");
            RenameColumn(table: "dbo.Patient", name: "DATE_OF_BIRTH", newName: "DateOfBirth");
            RenameColumn(table: "dbo.Patient", name: "LAST_NAME", newName: "LastName");
            RenameColumn(table: "dbo.Patient", name: "FIRST_NAME", newName: "FirstName");
            RenameColumn(table: "dbo.Patient", name: "PATIENT_ID", newName: "PatientId");
            AddForeignKey("dbo.Record", "PatientId", "dbo.Patient", "PatientId", cascadeDelete: true);
        }
    }
}
