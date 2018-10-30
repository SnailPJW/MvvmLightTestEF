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
    public class RecordMap : EntityTypeConfiguration<Record>
    {
        public RecordMap()
        {
            //Primary key
            this.HasKey(record => record.RecordId);
            this.Property(record => record.RecordId)
                .HasColumnType("bigint")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //Properties
            this.Property(record => record.RecordStatus)
                .HasMaxLength(50);

            

            //Table & column mappings
            //this.ToTable("Table_Name", "Schema_Name");//specify table name and schema name (optional) for model.
            this.Property(record => record.RecordId).HasColumnName("RECORD_ID");
            this.Property(record => record.RecordStatus).HasColumnName("RECORD_STATUS");
        }
    }
}
