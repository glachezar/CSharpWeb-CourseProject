namespace MyGarage.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using MyGarage.Data;
    using Interfaces;
    using Web.ViewModels.Part;
    using MyGarage.Data.Models;


    public class PartService : IPartService
    {
        private readonly MyGarageDbContext _context;

        public PartService(MyGarageDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<PartsViewModel>> AllPartsAsync()
        {
            IEnumerable<PartsViewModel> viewAllParts = await _context
                .Parts
                .Where(p => p.IsActive == true)
                .AsNoTracking()
                .Select(p => new PartsViewModel()
                {
                    Id = p.Id.ToString(),
                    PartName = p.PartName,
                    PartNumber = p.PartNumber,
                    Price = p.Price
                })
                .ToArrayAsync();

            return viewAllParts;
        }

        public async Task AddPartAsync(PartsViewModel part)
        {
            Part newPart = new Part()
            {
                PartNumber = part.PartNumber,
                PartName = part.PartName,
                Price = part.Price,
            };

            await this._context.AddAsync(newPart);
            await this._context.SaveChangesAsync();
        }

        public async Task<PartsViewModel> ViewPartDetailsByIdAsync(string id)
        {
            Part? part = await _context
                .Parts
                .Where(p => p.IsActive == true)
                .FirstOrDefaultAsync(v => v.Id.ToString() == id);

            if (part == null)
            {
                return null;
            }

            return new PartsViewModel()
            {
                Id = part!.Id.ToString(),
                PartName = part.PartName,
                PartNumber = part.PartNumber,
                Price = part.Price
            };
        }

        public async Task<bool> ExistingByIdAsync(string id)
        {
            bool result = await _context
                .Parts
                .Where(v => v.IsActive == true)
                .AnyAsync(v => v.Id.ToString() == id);

            return result;
        }

        public async Task<PartsViewModel> GetPartByIdAsync(string id)
        {
            Guid vId = Guid.Parse(id);
            var part= await _context.Parts.FindAsync(vId);

            PartsViewModel result = new PartsViewModel()
            {
                Id = part.Id.ToString(),
                PartName = part.PartName,
                PartNumber = part.PartNumber,
                Price = part.Price
            };

            return result;
        }

        public async Task<PartsViewModel> GetPartForEditByIdAsync(string id)
        {
            Part part = await _context
                .Parts
                .Where(v => v.IsActive == true)
                .FirstAsync(v => v.Id.ToString() == id);

            return new PartsViewModel
            {
                Id = part.Id.ToString(),
                PartName = part.PartName,
                PartNumber = part.PartNumber,
                Price = part.Price
            };
        }

        public async Task EditPartByIdAndFormModelAsync(string partId, PartsViewModel partModel) 
        {
            
                Part part = await _context
                    .Parts
                    .FirstAsync(v => v.Id.ToString() == partId);

                part.PartName = partModel.PartName;
                part.PartNumber = partModel.PartNumber;
                part.Price = partModel.Price;

                await _context.SaveChangesAsync();
        }

        public async Task<bool> SoftDeletePartAsync(Guid partId)
        {
            
            var part = await _context.Parts.FindAsync(partId);
            if (part == null)
            {
                return false;
            }

            part.IsActive = false;
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
