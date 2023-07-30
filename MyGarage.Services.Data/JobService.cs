namespace MyGarage.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using MyGarage.Data.Models;
    using MyGarage.Data;
    using Interfaces;
    using Web.ViewModels.Job;

    public class JobService : IJobService
    {

        private readonly MyGarageDbContext _context;

        public JobService(MyGarageDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<JobViewModel>> AllJobsAsync()
        {
            IEnumerable<JobViewModel> viewAllJobs = await this._context
                .Jobs
                .Where(j => j.IsActive == true)
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

            await _context.AddAsync(newJob);
            await this._context.SaveChangesAsync();
        }

        public async Task<JobViewModel> ViewJobDetailsByIdAsync(string id)
        {
            Job? job = await _context
                .Jobs
                .Where(p => p.IsActive == true)
                .FirstOrDefaultAsync(v => v.Id.ToString() == id);

            if (job == null)
            {
                return null;
            }

            return new JobViewModel
            {
                Id = job.Id.ToString(),
                JobName = job.JobName,
                Price = job.Price,

            };
        }

        public async Task<bool> ExistingByIdAsync(string id)
        {
            bool result = await _context
                .Jobs
                .Where(v => v.IsActive == true)
                .AnyAsync(v => v.Id.ToString() == id);

            return result;
        }

        public async Task<JobViewModel> GetJobByIdAsync(string id)
        {
            Guid jId = Guid.Parse(id);
            var job = await _context.Jobs.FindAsync(jId);

            JobViewModel result = new JobViewModel
            {
                Id = job.Id.ToString(),
                JobName = job.JobName,
                Price = job.Price
            };

            return result;
        }

        public async Task<AddJobViewModel> GetJobForEditByIdAsync(string id)
        {
            Job job = await _context
                .Jobs
                .Where(v => v.IsActive == true)
                .FirstAsync(v => v.Id.ToString() == id);

            return new AddJobViewModel
            {
                Id = job.Id.ToString(),
                JobName = job.JobName,
                Price = job.Price
            };
        }

        public async Task EditJobByIdAndFormModelAsync(string jobId, AddJobViewModel jobViewModel)
        {
            Job jobToEdit = await _context
            .Jobs
            .FirstAsync(v => v.Id.ToString() == jobId);

            jobToEdit.JobName = jobViewModel.JobName;
            jobToEdit.Price = jobViewModel.Price;

            await _context.SaveChangesAsync();
        }

        public async Task<bool> SoftDeleteJobAsync(Guid jobId)
        {
            var job = await _context.Jobs.FindAsync(jobId);
            if (job == null)
            {
                return false;
            }

            job.IsActive = false;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
