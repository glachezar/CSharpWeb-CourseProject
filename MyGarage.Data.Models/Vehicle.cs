using System.ComponentModel.DataAnnotations.Schema;

namespace MyGarage.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Vehicle
    {
        public Vehicle()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Make { get; set; } = null!;

        [Required]
        public string Model { get; set; } = null!;

        [Required]
        public string Vin { get; set; } = null!;


        public string EngineNumber { get; set; }

        public string RegNumber { get; set; }

        [Required]
        public string YearManufactured { get; set; } = null!;

        public string FuelType { get; set; } = null!;

        public string Mileage { get; set; }

        [ForeignKey(nameof(Customer))]
        public Guid? CustomerId { get; set; }

        public Customer? Customer { get; set; }
    }
}
