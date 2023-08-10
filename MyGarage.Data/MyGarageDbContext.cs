using MyGarage.Data.Configurations;

namespace MyGarage.Data
{
    using System.Reflection;
    using Microsoft.AspNetCore.Identity;

    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using Models;

    public class MyGarageDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public MyGarageDbContext(DbContextOptions<MyGarageDbContext> options)
            : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Part> Parts { get; set; }

        public DbSet<Job> Jobs { get; set; }

        public DbSet<JobCard> JobCards { get; set; }

        public DbSet<JobCardJob> JobCardJobs { get; set; }
        public DbSet<JobCardPart> JobCardParts { get; set; }

        public DbSet<Mechanic> Mechanics { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Assembly configAssembly = Assembly.GetAssembly(typeof(MyGarageDbContext)) ?? 
                                      Assembly.GetExecutingAssembly();

            builder.ApplyConfigurationsFromAssembly(configAssembly);

            //builder.ApplyConfiguration(new CustomerEntityConfiguration());

            builder.Entity<JobCardJob>()
                .HasKey(jcj => new { jcj.JobId, jcj.JobCardId });

            builder.Entity<JobCardPart>()
                .HasKey(jcp => new { jcp.JobCardId, jcp.PartId });

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}