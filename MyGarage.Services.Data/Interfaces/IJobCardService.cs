namespace MyGarage.Services.Data.Interfaces
{
    using Web.ViewModels.JobCard;

    public interface IJobCardService
    {
        Task<IEnumerable<JobCardViewModel>> ViewAllJobCardsAsync();
        
        Task CreateJobCardViewModelAsync(string id, CreateJobCardViewModel model);
    }
}
