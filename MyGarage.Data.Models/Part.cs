namespace MyGarage.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static MyGarage.Common.EntityValidationConstants.Part;

    public class Part
    {
        public Part()
        {
            this.Id = Guid.NewGuid();
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

        
        public Guid? JobCardId { get; set; }

        public JobCard? JobCard { get; set; }

    }
}
