namespace MyGarage.Web.ViewModels.Customer
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    using Data.Models;
    using Vehicle;
    using static Common.EntityValidationConstants.Customer;


    public class CustomerDetailsViewModel
    {
        public string Id { get; set; } = null!;

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(SurnameMaxLength, MinimumLength = SurnameMinLength)]
        public string Surname { get; set; } = null!;

        [StringLength(EgnMaxLength, MinimumLength = EgnMinLength)]
        public string? Egn { get; set; }

        [StringLength(AddressMaxLength, MinimumLength = AddressMinLength)]
        public string? Address { get; set; }

        [Required]
        [StringLength(EmailMaxLength, MinimumLength = EmailMinLength)]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength)]
        public string PhoneNumber { get; set; } = null!;

        public Guid? ApplicationUserId { get; set; }

        public ApplicationUser? ApplicationUser { get; set; }

        public virtual IEnumerable<VehicleViewModel>? Vehicles { get; set; }
    }
}
