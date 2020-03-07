using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HealthAPI.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }
        public string Name { get; set; }
        public ICollection<Ailment> Ailments { get; set; }
        public ICollection<Medication> Medications { get; set; }
    }
}