using Microsoft.EntityFrameworkCore;
using MyGarage.Data;
using MyGarage.Services.Data.Interfaces;
using MyGarage.Web.ViewModels.Mechanic;

namespace MyGarage.Services.Data
{


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
            throw new NotImplementedException();
        }

        public Task<MechanicViewModel> ViewMechanicDetailsByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistingByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<MechanicViewModel> GetMechanicByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<MechanicViewModel> GetMechanicForEditByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task EditMechanicByIdAndFormModelAsync(string vehicleId, MechanicViewModel mechanic)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SoftDeleteMechanicAsync(Guid mechanicId)
        {
            throw new NotImplementedException();
        }
    }
}
