namespace MyGarage.Data.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

public class CustomerEntityConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder
            .HasData(this.GenerateCustomers());

        builder
            .HasKey(c => c.Id);

        builder
            .HasMany(c => c.Vehicles)
            .WithOne(v => v.Customer)
            .HasForeignKey(v => v.CustomerId)
            .OnDelete(DeleteBehavior.SetNull);

        builder
            .HasOne(c => c.ApplicationUser)
            .WithOne(u => u.Customer)
            .HasForeignKey<Customer>(c => c.ApplicationUserId);
    }

    private Customer[] GenerateCustomers()
    {
        ICollection<Customer> customers = new HashSet<Customer>();

        var customer = new Customer()
        {
            Name = "Martin",
            Surname = "Martinov",
            PhoneNumber = "0888100100",
            Email = "Martinov@mcg.bg",
        };
        customers.Add(customer);

        customer = new Customer()
        {
            Name = "Pesho",
            Surname = "Peshov",
            PhoneNumber = "0888100200",
            Email = "Peshov@mcg.bg"
        };
        customers.Add(customer);

        customer = new Customer()
        {
            Name = "Ivan",
            Surname = "Ivanov",
            PhoneNumber = "0888100200",
            Email = "Ivanov@mcg.bg"
        };
        customers.Add(customer);

        return customers.ToArray();
    }
}