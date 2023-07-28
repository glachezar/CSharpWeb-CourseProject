namespace MyGarage.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static MyGarage.Common.EntityValidationConstants.Part;

    public class Part
    {
        public Part()
        {
            this.Id = Guid.NewGuid();
            this.IsActive = true;
            this.JobCard = new HashSet<JobCard>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string PartName { get; set; } = null!;

        [Required]
        [MaxLength(NumberMaxLength)]
        public string PartNumber { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        public bool IsActive { get; set; }

        public ICollection<JobCard>? JobCard { get; set; }

    }
}
