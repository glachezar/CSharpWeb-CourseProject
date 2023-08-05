namespace MyGarage.Web.ViewModels.Vehicle
{
    using Customer;

    public class VehicleDetailsViewModel : VehicleViewModel
    {

        public string? EngineNumber { get; set; }

        public string? FuelType { get; set; }

        public string? Mileage { get; set; }

        public CustomerInfoOnVehicleViewModel? VehicleOwner { get; set; }
    }
}
