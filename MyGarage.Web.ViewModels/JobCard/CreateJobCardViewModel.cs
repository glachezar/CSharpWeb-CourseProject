

namespace MyGarage.Web.ViewModels.JobCard
{
    using System.ComponentModel.DataAnnotations;

    using Mechanic;
    using Vehicle;
    using Part;
    using Job;

    public class CreateJobCardViewModel
    {
        public CreateJobCardViewModel()
        {
            Mechanics = new List<JobCardMechanicFormModel>();
            Parts = new List<JobCardPartSelectFormModel>();
            Jobs = new List<JobCardJobSelectFormModel>();
        }

        public DateTime CreatedOn { get; set; }

        public string Mileage { get; set; } = null!;

        [Display(Name = "Vehicle")]
        public string VehicleId { get; set; } = null!;

        [Display(Name = "Mechanic Name")]
        public string MechanicId { get; set; } = null!;

        public IEnumerable<JobCardMechanicFormModel>? Mechanics { get; set; } = null!;

        [Display(Name = "Job")]
        public string JobId { get; set; } = null!;

        public virtual IEnumerable<JobCardJobSelectFormModel>? Jobs { get; set; }

        [Display(Name = "Part")]
        public string PartId { get; set; } = null!;

        public virtual IEnumerable<JobCardPartSelectFormModel>? Parts { get; set; }
    }
}
