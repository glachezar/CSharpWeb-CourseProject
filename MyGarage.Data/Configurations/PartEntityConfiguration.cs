namespace MyGarage.Data.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Models;

public class PartEntityConfiguration : IEntityTypeConfiguration<Part>
{
    public void Configure(EntityTypeBuilder<Part> builder)
    {
        builder.HasData(this.GeneratePart());
    }

    private Part[] GeneratePart()
    {
        ICollection<Part> Parts = new HashSet<Part>();

        var part = new Part()
        {
            PartName = "Wishbone",
            PartNumber = "G40.3613/C",
            Price = 70.00M
        };
        Parts.Add(part);

        part = new Part()
        {
            PartName = "Handbrake cable",
            PartNumber = "G40.36415/C",
            Price = 65.00M
        };
        Parts.Add(part);

        return Parts.ToArray();
    }
}
