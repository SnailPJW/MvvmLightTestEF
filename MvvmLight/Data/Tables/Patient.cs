using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvvmLight4EF.Data.Tables
{
    [Table("Patient")]
    public class Patient
    {
        //Primary key
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long PatientId { get; set; }

        [Required]
        public string PatientName { get; set; }

        //Collection navigation property
        //public IList<Record> Recoreds { get; set; }
        public virtual ICollection<Record> Record { get; set; }
    }
}
