using MyGarage.Data;

namespace MyGarage.Services.Data
{
    using Interfaces;

    public class JobCardService : IJobCardService
    {
        private readonly MyGarageDbContext _context;

        public JobCardService(MyGarageDbContext context)
        {
            _context = context;
        }
    }
}
