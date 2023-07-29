namespace MyGarage.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using MyGarage.Data;
    using MyGarage.Data.Models;
    using Interfaces;
    using Web.ViewModels.Mechanic;


    public class MechanicService : IMechanicService
    {
        private readonly MyGarageDbContext _context;

        public MechanicService(MyGarageDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MechanicViewModel>> AllMechanicsAsync()
        {
            IEnumerable<MechanicViewModel> allMechanics = await this._context
                .Mechanics
                .AsNoTracking()
                .Select(m => new MechanicViewModel()
                {
                    Id = m.Id.ToString(),
                    Name = m.Name,
                    Surname = m.Surname,
                    PhoneNumber = m.PhoneNumber
                })
                .ToArrayAsync();


            return allMechanics;
        }

        public async Task AddMechanicAsync(MechanicViewModel mechanic)
        {
            Mechanic newMechanic = new Mechanic()
            {
                Name = mechanic.Name,
                Surname = mechanic.Surname,
                PhoneNumber = mechanic.PhoneNumber,
            };

            await this._context.AddAsync(newMechanic);
            await this._context.SaveChangesAsync();
        }

        public async Task<MechanicViewModel> ViewMechanicDetailsByIdAsync(string id)
        {
            Mechanic? mechanic = await _context
                .Mechanics
                .Where(p => p.IsActive == true)
                .FirstOrDefaultAsync(v => v.Id.ToString() == id);

            if (mechanic == null)
            {
                return null;
            }

            return new MechanicViewModel
            {
                Id = mechanic.Id.ToString(),
                Name = mechanic.Name,
                Surname = mechanic.Surname,
                PhoneNumber = mechanic.PhoneNumber
            };
        }

        public async Task<bool> ExistingByIdAsync(string id)
        {
            bool result = await _context
                .Mechanics
                .Where(v => v.IsActive == true)
                .AnyAsync(v => v.Id.ToString() == id);

            return result;
        }

        public async Task<MechanicViewModel> GetMechanicByIdAsync(string id)
        {
            Guid mId = Guid.Parse(id);
            var mechanic = await _context.Mechanics.FindAsync(mId);

            MechanicViewModel result = new MechanicViewModel()
            {
                Id = mechanic.Id.ToString(),
                Name = mechanic.Name,
                Surname = mechanic.Surname,
                PhoneNumber = mechanic.PhoneNumber
            };

            return result;
        }

        public async Task<MechanicViewModel> GetMechanicForEditByIdAsync(string id)
        {
            Mechanic mechanic = await _context
                .Mechanics
                .Where(v => v.IsActive == true)
                .FirstAsync(v => v.Id.ToString() == id);

            return new MechanicViewModel
            {
                Id = mechanic.Id.ToString(),
                Name = mechanic.Name,
                Surname = mechanic.Surname,
                PhoneNumber = mechanic.PhoneNumber

            };
        }

        public async Task EditMechanicByIdAndFormModelAsync(string mechanicId, MechanicViewModel mechanic)
        {
            Mechanic mechanicToEdit = await _context
                .Mechanics
                .FirstAsync(v => v.Id.ToString() == mechanicId);

            mechanicToEdit.Name = mechanic.Name;
            mechanicToEdit.Surname = mechanic.Surname;
            mechanicToEdit.PhoneNumber = mechanic.PhoneNumber;

            await _context.SaveChangesAsync();
        }

        public async Task<bool> SoftDeleteMechanicAsync(Guid mechanicId)
        {
            var mechanic = await _context.Mechanics.FindAsync(mechanicId);
            if (mechanic == null)
            {
                return false;
            }

            mechanic.IsActive = false;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
