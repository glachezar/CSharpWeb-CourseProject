
namespace MyGarage.Services.Data.Interfaces
{
    using MyGarage.Web.ViewModels.Job;

    public interface IJobService
    {
        Task<IEnumerable<JobViewModel>> AllJobsAsync();

        Task AddJobAsync(AddJobViewModel job);
    }
}
