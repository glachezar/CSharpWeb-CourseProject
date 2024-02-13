namespace MyGarage.Data.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;


public class JobCardEntityConfiguration : IEntityTypeConfiguration<JobCard>
{
    public void Configure(EntityTypeBuilder<JobCard> builder)
    {
        //builder.HasData(this.GenerateJobCards());
        builder.Property(jc => jc.CreatedOn)
            .HasDefaultValueSql("GETDATE()");

    }

}
