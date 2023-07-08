namespace MyGarage.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
            OwnedVehicles = new HashSet<Vehicle>();
        }

        public virtual ICollection<Vehicle> OwnedVehicles { get; set; }
    }
}
