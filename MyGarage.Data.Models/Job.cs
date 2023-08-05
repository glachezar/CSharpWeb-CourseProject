namespace MyGarage.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static MyGarage.Common.EntityValidationConstants.Job;

    public class Job
    {
        public Job()
        {
            this.Id = Guid.NewGuid();
            this.IsActive = true;
            this.JobCards = new HashSet<JobCard>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string JobName { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        public bool IsActive { get; set; }

        public ICollection<JobCard> JobCards { get; set; }

    }
}
