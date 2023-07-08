using Microsoft.EntityFrameworkCore;
using MyGarage.Data.Models;

namespace MyGarage.Data.Configurations
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MechanicEntityConfiguration : IEntityTypeConfiguration<Mechanic>
    {
        public void Configure(EntityTypeBuilder<Mechanic> builder)
        {
            builder.HasData(GenerateMechanic());
        }

        private Mechanic[] GenerateMechanic()
        {
            ICollection<Mechanic> mechanics = new HashSet<Mechanic>();

            Mechanic mechanic;

            mechanic = new Mechanic()
            {
                Name = "Ivan",
                Surname = "Ivanov",
                PhoneNumber = "0888123456"
            };
            mechanics.Add(mechanic);

            mechanic = new Mechanic()
            {
                Name = "Petar",
                Surname = "Petrov",
                PhoneNumber = "0888123457"
            };
            mechanics.Add(mechanic);




            return mechanics.ToArray();
        }
    }
}
