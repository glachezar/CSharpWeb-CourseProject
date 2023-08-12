namespace MyGarage.Web.ViewModels.JobCard
{
    using Job;


    public class AddJobToJobCardViewModel : JobCardViewModel
    {
        public IEnumerable<JobCardJobSelectFormModel>? Jobs { get; set; }

        public Guid SelectedJobId { get; set; }
    }
}
