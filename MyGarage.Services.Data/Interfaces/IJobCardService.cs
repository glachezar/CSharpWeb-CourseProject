namespace MyGarage.Services.Data.Interfaces
{
    using Web.ViewModels.JobCard;

    public interface IJobCardService
    {
        Task CreateJobCardViewModelAsync(string id, CreateJobCardViewModel model);

        
    }
}
