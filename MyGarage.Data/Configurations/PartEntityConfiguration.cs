using Microsoft.EntityFrameworkCore;

namespace MyGarage.Data.Configurations
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyGarage.Data.Models;

    public class PartEntityConfiguration : IEntityTypeConfiguration<Part>
    {
        public void Configure(EntityTypeBuilder<Part> builder)
        {
            builder.HasData(this.GeneratePart());

        }


        private Part[] GeneratePart()
        {
            ICollection<Part> Parts = new HashSet<Part>();

            Part part;

            part = new Part()
            {
                PartName = "Wishbone",
                PartNumber = "G40.3613/C"
            };
            Parts.Add(part);

            part = new Part()
            {
                PartName = "Handbrake cable",
                PartNumber = "G40.36415/C"
            };
            Parts.Add(part);




            return Parts.ToArray();
        }


    }
}
