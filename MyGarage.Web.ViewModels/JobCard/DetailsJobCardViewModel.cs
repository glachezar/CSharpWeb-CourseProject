namespace MyGarage.Web.ViewModels.JobCard
{

    using Job;
    using Mechanic;
    using Part;
    using Vehicle;

    public class DetailsJobCardViewModel
    {
        public string Id { get; set; } = null!;

        public string CreatedOn { get; set; } = null!;

        public string Mileage { get; set; } = null!;

        public JobCardVehicleSelectFormModel? Vehicle { get; set; }

        public JobCardMechanicFormModel? Mechanic { get; set; }

        public virtual ICollection<JobViewModel>? Jobs { get; set; }

        public decimal TotalAmountForParts { get; set; }

        public virtual ICollection<PartsViewModel>? Parts { get; set; }

        public decimal TotalAmountForLabor { get; set; }
    }
}
