namespace MyGarage.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

   
    public class JobCard
    {
        public JobCard()
        {
            this.Id = Guid.NewGuid();
            this.JobCardJobs = new HashSet<JobCardJob>();
            this.JobCardParts = new HashSet<JobCardPart>();
        }

        [Key]
        public Guid Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Mileage { get; set; } = null!;

        [ForeignKey(nameof(Vehicle))]
        public Guid VehicleId { get; set; }

        public Vehicle? Vehicle { get; set; }

        [ForeignKey(nameof(Mechanic))]
        public Guid MechanicId { get; set; }

        public Mechanic? Mechanic { get; set; }

        public virtual ICollection<JobCardJob>? JobCardJobs { get; set; }

        public virtual ICollection<JobCardPart>? JobCardParts { get; set; }
    }
}
