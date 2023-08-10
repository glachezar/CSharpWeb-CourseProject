namespace MyGarage.Services.Data
{
    using System.Collections;
    using MyGarage.Data.Models;
    using Web.ViewModels.JobCard;
    using MyGarage.Data;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Web.ViewModels.Vehicle;
    using System.Linq;
    using Web.ViewModels.Job;
    using Web.ViewModels.Mechanic;
    using Web.ViewModels.Part;

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


        public async Task<IEnumerable<JobCardViewModel>> ViewAllJobCardsAsync()
        {
            IEnumerable<JobCardViewModel> allJobCards = await _context
                .JobCards
                .Where(jc => jc.Vehicle.IsActive == true)
                .OrderByDescending(jc => jc.CreatedOn)
                .AsNoTracking()
                .Select(jc => new JobCardViewModel()
                {
                    Id = jc.Id.ToString(),
                    CreatedOn = jc.CreatedOn.Date.ToString("d"),
                    Vehicle = new JobCardVehicleSelectFormModel()
                    {
                        Id = jc.Vehicle.Id.ToString(),
                        Make = jc.Vehicle.Make,
                        Model = jc.Vehicle.Model,
                        Vin = jc.Vehicle.Vin
                    }

                })
                .ToArrayAsync();

            return allJobCards;
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

        //public async Task<DetailsJobCardViewModel> GetJobCardForDetailsViewAsync(string id)
        //{
        //    DetailsJobCardViewModel? card = await _context
        //        .JobCards
        //        .Include(m => m.Mechanic)!
        //        .Include(jcp => jcp.JobCardParts)!
        //        .ThenInclude(jcp => jcp.Part)!
        //        .Include(jcj => jcj.JobCardJobs)!
        //        .ThenInclude(jcj => jcj.Job)
        //        .Include(v => v.Vehicle)
        //        .AsNoTracking()
        //        .Select(c =>new DetailsJobCardViewModel
        //        {
        //            Id = c.Id.ToString(),
        //            CreatedOn = c.CreatedOn.ToString("d"),
        //            Mileage = c.Mileage,
        //            Vehicle = new JobCardVehicleSelectFormModel()
        //            {
        //                Make = c.Vehicle.Make,
        //                Model = c.Vehicle.Model,
        //                Vin = c.Vehicle.Vin
        //            },
        //            Mechanic = new JobCardMechanicFormModel()
        //            {
        //                Name = c.Mechanic!.Name,
        //                LastName = c.Mechanic.Surname
        //            },
        //            Jobs =  c.JobCardJobs!
        //                .Where(j => j.JobCard.Id.ToString() == id)
        //                .Select(j => new JobViewModel
        //                {
        //                    Id = j.Job.Id.ToString(),
        //                    JobName = j.Job.JobName,
        //                    Price = j.Job.Price
        //                })
        //                .ToArray(),
        //            TotalAmountForParts = 0,
        //            Parts = c.JobCardParts!
        //                .Where(j => j.JobCard.Id.ToString() == id)
        //                .Select(p => new PartsViewModel
        //                {
        //                    Id = p.Part.Id.ToString(),
        //                    PartName = p.Part.PartName,
        //                    PartNumber = p.Part.PartNumber,
        //                    Price = p.Part.Price
        //                })
        //                .ToArray(),

        //            TotalAmountForLabor = 0,
        //        })
        //        .FirstOrDefaultAsync(jc => jc.Id.ToString() == id);


        //    if (card == null)
        //    {
        //        return null;
        //    }


        //    return card;
        //}

        public async Task<DetailsJobCardViewModel> GetJobCardForDetailsViewAsync(string id)
        {
            var card = await _context.JobCards
                .Include(m => m.Mechanic)
                .Include(jcp => jcp.JobCardParts)
                .ThenInclude(jcp => jcp.Part)
                .Include(jcj => jcj.JobCardJobs)
                .ThenInclude(jcj => jcj.Job)
                .Include(v => v.Vehicle)
                .AsNoTracking()
                .Where(c => c.Id.ToString() == id)
                .Select(c => new DetailsJobCardViewModel
                {
                    Id = c.Id.ToString(),
                    CreatedOn = c.CreatedOn.ToString("d"),
                    Mileage = c.Mileage,
                    Vehicle = new JobCardVehicleSelectFormModel
                    {
                        Make = c.Vehicle.Make,
                        Model = c.Vehicle.Model,
                        Vin = c.Vehicle.Vin
                    },
                    Mechanic = new JobCardMechanicFormModel
                    {
                        Name = c.Mechanic.Name,
                        LastName = c.Mechanic.Surname
                    },
                    Jobs = c.JobCardJobs
                        .Select(j => new JobViewModel
                        {
                            Id = j.Job.Id.ToString(),
                            JobName = j.Job.JobName,
                            Price = j.Job.Price
                        })
                        .ToArray(),
                    TotalAmountForParts = c.JobCardParts
                        .Sum(p => p.Part.Price), 
                    Parts = c.JobCardParts
                        .Select(p => new PartsViewModel
                        {
                            Id = p.Part.Id.ToString(),
                            PartName = p.Part.PartName,
                            PartNumber = p.Part.PartNumber,
                            Price = p.Part.Price
                        })
                        .ToArray(),
                    TotalAmountForLabor = c.JobCardJobs.Sum(j => j.Job.Price),
                })
                .FirstOrDefaultAsync();

            return card;
        }

        public Task<DetailsJobCardViewModel> GetJobCardFofDeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteJobCardByIdAsync(string id)
        {
            JobCard? card = await _context.JobCards.FirstOrDefaultAsync(jc => jc.Id.ToString() == id);

            if (card == null)
            {
                return false;
            }

            _context.JobCards.Remove(card);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
