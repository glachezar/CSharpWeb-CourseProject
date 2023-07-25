using Microsoft.EntityFrameworkCore;
using MyGarage.Data;
using MyGarage.Data.Models;

namespace MyGarage.Services.Data
{
    using Interfaces;
    using Web.ViewModels.Part;



    public class PartService : IPartService
    {
        private readonly MyGarageDbContext context;

        public PartService(MyGarageDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<AllPartsViewModel>> AllPartsAsync()
        {
            IEnumerable<AllPartsViewModel> viewAllParts = await context
                .Parts
                .AsNoTracking()
                .Select(p => new AllPartsViewModel()
                {
                    Id = p.Id.ToString(),
                    PartName = p.PartName,
                    PartNumber = p.PartNumber,
                    Price = p.Price
                })
                .ToArrayAsync();

            return viewAllParts;
        }

        public async Task AddPartAsync(AllPartsViewModel part)
        {
            Part newPart = new Part()
            {
                PartNumber = part.PartNumber,
                PartName = part.PartName,
                Price = part.Price,
            };

            await this.context.AddAsync(newPart);
            await this.context.SaveChangesAsync();
        }
    }
}
