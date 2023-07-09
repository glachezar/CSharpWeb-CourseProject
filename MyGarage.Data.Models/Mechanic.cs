namespace MyGarage.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static MyGarage.Common.EntityValidationConstants.Mechanic;
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
