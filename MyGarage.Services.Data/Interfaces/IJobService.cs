
namespace MyGarage.Services.Data.Interfaces
{
    using Web.ViewModels.Job;

    public interface IJobService
    {
        Task<IEnumerable<JobViewModel>> AllJobsAsync();

        Task<IEnumerable<JobCardJobSelectFormModel>> AllJobsForFormModelAsync();

        Task AddJobAsync(AddJobViewModel job);

        Task<JobViewModel> ViewJobDetailsByIdAsync(string id);

        Task<bool> ExistingByIdAsync(string id);

        Task<JobViewModel> GetJobByIdAsync(string id);

        Task<AddJobViewModel> GetJobForEditByIdAsync(string id);

        Task EditJobByIdAndFormModelAsync(string jobId, AddJobViewModel jobViewModel);

        Task<bool> SoftDeleteJobAsync(Guid jobId);
    }
}
