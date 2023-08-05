namespace MyGarage.Services.Data
{
    using MyGarage.Data.Models;
    using Web.ViewModels.JobCard;
    using MyGarage.Data;
    using Interfaces;

    public class JobCardService : IJobCardService
    {
        private readonly MyGarageDbContext _context;
        private readonly IJobService _jobService;
        private readonly IPartService _partService;
        private readonly IVehicleService _vehicleService;
        private readonly IMechanicService _mechanicService;

        public JobCardService(MyGarageDbContext context, IJobService jobService, IPartService partService, IVehicleService vehicleService, IMechanicService mechanicService)
        {
            _context = context;
            _jobService = jobService;
            _partService = partService;
            _vehicleService = vehicleService;
            _mechanicService = mechanicService;
        }

        public async Task CreateJobCardViewModelAsync(string id, CreateJobCardViewModel model)
        {
            var vehicle = await _context.Vehicles.FindAsync(Guid.Parse(id));
            var mechanic = await _context.Mechanics.FindAsync(Guid.Parse(model.MechanicId));
            var job = await _context.Jobs.FindAsync(Guid.Parse(model.JobId));
            var part = await _context.Parts.FindAsync(Guid.Parse(model.PartId));



            JobCard newJob = new JobCard()
            {

                Mileage = model.Mileage,

                VehicleId = Guid.Parse(id),
                Vehicle = vehicle,

                MechanicId = mechanic.Id,
                Mechanic = mechanic
            };

            JobCardJob jobCardJob = new JobCardJob()
            {
                JobId = job.Id,
                Job = job,

                JobCardId = newJob.Id,
                JobCard = newJob
            };

            JobCardPart jobCardPart = new JobCardPart()
            {
                PartId = part.Id,
                Part = part,

                JobCardId = newJob.Id,
                JobCard = newJob
            };

            newJob.JobCardJobs?.Add(jobCardJob);
            newJob.JobCardParts?.Add(jobCardPart);

            mechanic.JobCards?.Add(newJob);
            vehicle.JobCards?.Add(newJob);

            await _context.JobCards.AddAsync(newJob);

            await _context.SaveChangesAsync();
        }
    }
}
