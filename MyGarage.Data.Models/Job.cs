using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyGarage.Data.Models
{
    using static MyGarage.Common.EntityValidationConstants.Job;
    public class Job
    {
        public Job()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public string JobName { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        [ForeignKey(nameof(JobCard))]
        public Guid? JobCardId { get; set; }
        
        public JobCard? JobCard { get; set; }

    }
}
