using MvvmLight4EF.Data.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmLight.Data.Maps
{
    public class PatientMap : EntityTypeConfiguration<Patient>
    {
        public PatientMap()
        {
            //Primary key
            this.HasKey(patient => patient.PatientId);
            this.Property(patient => patient.PatientId)
                .HasColumnType("bigint")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //Properties
            this.Property(patient => patient.FirstName)
                .IsRequired()
                .HasMaxLength(50);
            this.Property(patient => patient.LastName)
                .HasMaxLength(50);

            this.Ignore(patient => patient.FullName);

            //this.Property(patient => patient.DateOfBirth);

            //Table & column mappings
            //this.ToTable("Table_Name", "Schema_Name");//specify table name and schema name (optional) for model.
            this.Property(patient => patient.PatientId).HasColumnName("PATIENT_ID");
            this.Property(patient => patient.FirstName).HasColumnName("FIRST_NAME");
            this.Property(patient => patient.LastName).HasColumnName("LAST_NAME");
            this.Property(patient => patient.DateOfBirth).HasColumnName("DATE_OF_BIRTH");
        }
    }
}
