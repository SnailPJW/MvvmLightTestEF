using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvvmLight4EF.Data.Tables
{
    [Table("Record")]
    public class Record
    {
        //Primary key
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long RecordId { get; set; }

        [Required]
        public string RecordStatus { get; set; }

        //Navigation property
        //public Patient Patient { get; set; }
        //Foreign Key Convention
        public long PatientId { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
