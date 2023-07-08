using System.ComponentModel.DataAnnotations;

namespace MyGarage.Data.Models
{
    public class Mechanic
    {
        public Mechanic()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Surname { get; set; } = null!;

        [Required]
        public string PhoneNumber { get; set; } = null!;

        public ICollection<JobCard>? JobCards { get; set; }

    }
}
