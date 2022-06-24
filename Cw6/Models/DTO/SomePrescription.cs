using System;
using System.Collections.Generic;

namespace Cw6.Models.DTO
{
    public class SomePrescription
    {
        public int IdPrescription { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public IEnumerable<SomePrescriptionMedicament> PrescriptionMedicaments { get; set; }
        public virtual SomePatient SomePatient { get; set; }
        public virtual SomeKindOfDoctor SomeDoctor { get; set; }
    }
}
