namespace MyGarage.Services.Data.Interfaces
{
    using Web.ViewModels.JobCard;

    public interface IJobCardService
    {
        Task<IEnumerable<JobCardViewModel>> ViewAllJobCardsAsync();
        
        Task CreateJobCardViewModelAsync(string id, CreateJobCardViewModel model);

        Task<DetailsJobCardViewModel> GetJobCardForDetailsViewAsync(string id);

        Task<bool> DeleteJobCardByIdAsync(string id);

        Task<AddPartToJobCardViewModel> GetJobCardToAddPartAsync(string id);

        Task<bool> AddPartToJobCardAsync(string id, AddPartToJobCardViewModel model);
    }
}
