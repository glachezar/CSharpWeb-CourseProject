using System.ComponentModel.DataAnnotations.Schema;

namespace MyGarage.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Customer
    {
        public Customer()
        {
            this.Id = Guid.NewGuid();
            this.Vehicles = new HashSet<Vehicle>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Surname { get; set; } = null!;


        public string? Egn { get; set; }


        public string? Address { get; set; }

        [Required]
        public string Email { get; set; } = null!;

        [Required] 
        public string PhoneNumber { get; set; } = null!;

        
        public Guid? VehicleId { get; set; }

        public virtual ICollection<Vehicle>? Vehicles { get; set; }
    }
}
