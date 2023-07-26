namespace MyGarage.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static MyGarage.Common.EntityValidationConstants.Vehicle;

    public class Vehicle
    {
        public Vehicle()
        {
            this.Id = Guid.NewGuid();
            this.IsActive = true;
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(MakeMaxLength)]
        public string Make { get; set; } = null!;

        [Required]
        [MaxLength(ModelNameMaxLength)]
        public string Model { get; set; } = null!;

        [Required]
        [MaxLength(VinMaxLength)]
        public string Vin { get; set; } = null!;

        [MaxLength(EngineNumberMaxLength)]
        public string EngineNumber { get; set; }

        [MaxLength(RegistrationPlateMaxLength)]
        public string RegNumber { get; set; }

        [Required]
        [MaxLength(YearMadeMaxLength)]
        public string YearManufactured { get; set; } = null!;

        public string FuelType { get; set; } = null!;

        [MaxLength(MileageMaxLength)]
        public string Mileage { get; set; }

        public bool IsActive { get; set; }

        [ForeignKey(nameof(Customer))]
        public Guid? CustomerId { get; set; }

        public Customer? Customer { get; set; }
    }
}
