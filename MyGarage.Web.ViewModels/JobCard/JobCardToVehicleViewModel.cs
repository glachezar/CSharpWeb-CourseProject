namespace MyGarage.Web.ViewModels.JobCard
{
    using Mechanic;

    public class JobCardToVehicleViewModel
    {
        public string Id { get; set; } = null!;

        public string CreatedOn { get; set; } = null!;

        public string Mileage { get; set;} = null!;

        public JobCardMechanicFormModel Mechanic { get; set; } = null!;
    }
}
