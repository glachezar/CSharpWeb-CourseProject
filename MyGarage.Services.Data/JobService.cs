namespace MyGarage.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using MyGarage.Data.Models;
    using MyGarage.Data;
    using Interfaces;
    using Web.ViewModels.Job;


    public class JobService : IJobService
    {

        private readonly MyGarageDbContext _dbContext;

        public JobService(MyGarageDbContext context)
        {
            _dbContext = context;
        }


        public async Task<IEnumerable<JobViewModel>> AllJobsAsync()
        {
            IEnumerable<JobViewModel> viewAllJobs = await this._dbContext
                .Jobs
                .AsNoTracking()
                .Select(j => new JobViewModel
                {
                    Id = j.Id.ToString(),
                    JobName = j.JobName,
                    Price = j.Price
                })
                .ToArrayAsync();

            return viewAllJobs;
        }

        public async Task AddJobAsync(AddJobViewModel job)
        {
            Job newJob = new Job
            {
                JobName = job.JobName,
                Price = job.Price,
            };

            await _dbContext.AddAsync(newJob);
            await this._dbContext.SaveChangesAsync();
        }
    }
}
