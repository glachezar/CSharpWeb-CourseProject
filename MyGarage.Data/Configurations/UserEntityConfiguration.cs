namespace MyGarage.Data.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

public class UserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.HasData(GenerateUser());
    }

    private ApplicationUser[] GenerateUser()
    {
        ICollection<ApplicationUser> users = new HashSet<ApplicationUser>();

        var newUser = new ApplicationUser
        {
            UserName = "martinov@mcg.bg",
            NormalizedUserName = "MARTINOV@MCG.BG",
            Email = "martinov@mcg.bg",
            NormalizedEmail = "MARTINOV@MCG.BG",
            FirstName = "Martin",
            LastName = "Martinov",
        };
        users.Add(newUser);

        newUser = new ApplicationUser
        {
            UserName = "admin",
            Email = "admin@mcg.bg",
            FirstName = "Admin",
            LastName = "Adminov",
        };
        users.Add(newUser);

        return users.ToArray();
    }
}