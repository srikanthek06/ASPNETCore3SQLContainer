using System.ComponentModel.DataAnnotations;

namespace HealthAPI.Models
{
    public class Medication
    {
        [Key]
        public string Name { get; set; }
        public string Doses { get; set; }
    }
}