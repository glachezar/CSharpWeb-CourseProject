namespace MyGarage.Web.ViewModels.JobCard
{
    using Part;


    public class AddPartToJobCardViewModel : JobCardViewModel
    {

        public IEnumerable<JobCardPartSelectFormModel> Parts { get; set; }

        public Guid SelectedPartId { get; set; } 
    }
}
