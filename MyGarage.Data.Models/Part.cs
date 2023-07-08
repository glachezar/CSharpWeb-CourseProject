namespace MyGarage.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Part
    {
        public Part()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public string PartName { get; set; } = null!;

        [Required]
        public string PartNumber { get; set; } = null!;

        
        public Guid? JobCardId { get; set; }

        public JobCard? JobCard { get; set; }

    }
}
