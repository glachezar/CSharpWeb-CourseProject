﻿namespace MyGarage.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
            this.Vehicles = new HashSet<Vehicle>();
        }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        [ForeignKey(nameof(Customer))]
        public Guid CustomerId { get; set; }

        public Customer Customer { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
