namespace MyGarage.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static MyGarage.Common.EntityValidationConstants.Mechanic;
    public class Mechanic
    {
        public Mechanic()
        {
            this.Id = Guid.NewGuid();
            this.JobCards = new HashSet<JobCard>();
            this.IsActive = true;
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(SurnameMaxLength)]
        public string Surname { get; set; } = null!;

        [Required]
        [MaxLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; } = null!;

        public bool IsActive { get; set; }

        public ICollection<JobCard>? JobCards { get; set; }

    }
}
