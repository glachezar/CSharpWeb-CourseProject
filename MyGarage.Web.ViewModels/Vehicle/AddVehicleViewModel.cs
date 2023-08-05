namespace MyGarage.Web.ViewModels.Vehicle
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Vehicle;

    public class AddVehicleViewModel
    {

        [Required]
        [StringLength(MakeMaxLength, MinimumLength = MakeMinLength)]
        public string Make { get; set; } = null!;

        [Required]
        [StringLength(ModelNameMaxLength, MinimumLength = ModelNameMinLength)]
        public string Model { get; set; } = null!;

        [Required]
        [StringLength(VinMaxLength, MinimumLength = VinMinLength)]
        public string Vin { get; set; } = null!;

        [StringLength(EngineNumberMaxLength, MinimumLength = EngineNumberMinLength)]
        public string? EngineNumber { get; set; } 

        [StringLength(RegistrationPlateMaxLength, MinimumLength = RegistrationPlateMinLength)]
        public string? RegNumber { get; set; }

        [Required]
        [StringLength(YearMadeMaxLength, MinimumLength = YearMadeMinLength)]
        public string YearManufactured { get; set; } = null!;

        [Required]
        public string FuelType { get; set; } = null!;

        [StringLength(MileageMaxLength, MinimumLength = MileageMinLength)]
        public string? Mileage { get; set; }

        public string? CustomerId { get; set; }
    }
}
