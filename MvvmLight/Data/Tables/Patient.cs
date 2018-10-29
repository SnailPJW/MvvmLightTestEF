using System;
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
        public string FirstName { get; set; }

        public string LastName { get; set; }

        //[StringLength(100)]
        //[MinLength(3),MaxLength(100)]
        [NotMapped] // computed / Derived fields 
        public string FullName => string.Format("{0} {1}", FirstName, LastName);


        public DateTime? DateOfBirth { get; set; }
        //Collection navigation property
        //public IList<Record> Recoreds { get; set; }
        public virtual ICollection<Record> Record { get; set; }
    }
}
