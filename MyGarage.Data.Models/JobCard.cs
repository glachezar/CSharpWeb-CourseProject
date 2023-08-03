namespace MyGarage.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

   
    public class JobCard
    {
        public JobCard()
        {
            this.Id = Guid.NewGuid();
            this.Jobs = new HashSet<Job>();
            this.Parts = new HashSet<Part>();
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

        [ForeignKey(nameof(Jobs))]
        public Guid JobId { get; set; }
        public virtual IEnumerable<Job>? Jobs { get; set; }

        [ForeignKey(nameof(Parts))]
        public Guid PartId { get; set; }
        
        public virtual IEnumerable<Part>? Parts { get; set; }
    }
}
