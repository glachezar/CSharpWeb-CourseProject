namespace MyGarage.Web.ViewModels.Vehicle
{
    using Customer;
    using JobCard;

    public class VehicleDetailsViewModel : VehicleViewModel
    {

        public string? EngineNumber { get; set; }

        public string? FuelType { get; set; }

        public string? Mileage { get; set; }

        public CustomerInfoOnVehicleViewModel? VehicleOwner { get; set; }

        public IEnumerable<JobCardToVehicleViewModel>? JobCards { get; set; }
    }
}
