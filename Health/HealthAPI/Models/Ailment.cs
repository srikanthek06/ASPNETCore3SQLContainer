using System.ComponentModel.DataAnnotations;
namespace HealthAPI.Models
{
    public class Ailment
    {

        [Key]
        public string Name { get; set; }
    }
}