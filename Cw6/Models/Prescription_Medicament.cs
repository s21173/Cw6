using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cw6.Models
{
    public class Prescription_Medicament
    {
        public int IdMedicament { get; set; }

        public int IdPrescription { get; set; }

        public int? Dose { get; set; }

        [Required]
        [MaxLength(100)]
        public string Details { get; set; }

        [ForeignKey("IdPrescription")]
        public virtual Prescription Prescription { get; set; }

        [ForeignKey("IdMedicament")]
        public virtual Medicament Medicament { get; set; }
    }
}
