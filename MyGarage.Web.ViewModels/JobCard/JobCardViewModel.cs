namespace MyGarage.Web.ViewModels.JobCard
{
    using Vehicle;


    public class JobCardViewModel
    {
        public string Id { get; set; } = null!;

        public string CreatedOn { get; set; } = null!;

        public JobCardVehicleSelectFormModel Vehicle { get; set; } = null!;

    }
}
