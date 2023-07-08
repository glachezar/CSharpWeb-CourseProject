﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyGarage.Data.Models;

namespace MyGarage.Data.Configurations
{

    public class JobEntityConfiguration : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.HasData(GenerateJob());
        }

        private Job[] GenerateJob()
        {
            ICollection<Job> Jobs = new HashSet<Job>();

            Job job;

            job = new Job()
            {
                JobName = "Oil change",
                Price = 50.00M,
            };
            Jobs.Add(job);

            job = new Job()
            {
                JobName = "Tyre replacement",
                Price = 20.00M,
            };
            Jobs.Add(job);




            return Jobs.ToArray();
        }
    }

}
