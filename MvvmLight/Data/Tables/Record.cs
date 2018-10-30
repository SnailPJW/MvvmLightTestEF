using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvvmLight4EF.Data.Tables
{
    [Table("Record")]
    public class Record
    {
        //Primary key
        //[Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]//[Key] identity (auto-increment) column
        public long RecordId { get; set; }

        //[Required]
        //[Column("StatusOfRecord", TypeName = "varchar", Order = 1)]
        public string RecordStatus { get; set; }

        //[Range(0,4)]
        public int? RecordStatusRange { get; set; }
        //Navigation property
        //public Patient Patient { get; set; }
        //Foreign Key Convention
        //public long PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
