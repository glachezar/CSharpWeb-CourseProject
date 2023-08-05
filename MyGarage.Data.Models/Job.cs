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
            this.JobCardJobs = new HashSet<JobCardJob>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string JobName { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        public bool IsActive { get; set; }

        public ICollection<JobCardJob> JobCardJobs { get; set; }

    }
}
