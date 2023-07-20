namespace MyGarage.Web.ViewModels.Vehicle
{

    public class VehicleDetailsViewModel
    {
        public string Id { get; set; } = null!;

        public string Make { get; set; } = null!;

        public string Model { get; set; } = null!;

        public string Vin { get; set; } = null!;

        public string? EngineNumber { get; set; }

        public string? RegNumber { get; set; }

        public string YearManufactured { get; set; } = null!;

        public string? FuelType { get; set; }

        public string? Mileage { get; set; }
    }
}
