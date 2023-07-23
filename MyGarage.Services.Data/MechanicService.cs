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
    }
}
