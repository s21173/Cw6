using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cw6.Models
{
    public class Prescription
    {
        [Key]
        public int IdPrescription { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        public int IdPatient { get; set; }
        public int IdDoctor { get; set; }

        [ForeignKey("IdPatient")]
        public virtual Patient Patient { get; set; }
        [ForeignKey("IdDoctor")]
        public virtual Doctor Doctor { get; set; }

        public virtual ICollection<Prescription_Medicament> Prescription_Medicaments { get; set; }
    }
}
