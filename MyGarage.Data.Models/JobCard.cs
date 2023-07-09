namespace MyGarage.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    using static MyGarage.Common.EntityValidationConstants.JobCard;

    public class JobCard
    {
        public JobCard()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Mileage { get; set; } = null!;

        [ForeignKey(nameof(Vehicle))]
        public Guid VehicleId { get; set; }

        public Vehicle Vehicle { get; set; } = null!;

        [ForeignKey(nameof(Mechanic))]
        public Guid MechanicId { get; set; }

        public Mechanic Mechanic { get; set; }

        public virtual ICollection<Job>? Jobs { get; set; }

        
        public virtual ICollection<Part>? Parts { get; set; }
    }
}
