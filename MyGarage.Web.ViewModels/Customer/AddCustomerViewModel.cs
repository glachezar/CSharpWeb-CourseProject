namespace MyGarage.Web.ViewModels.Customer
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.Customer;

    public class AddCustomerViewModel
    {


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
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength)]
        public string PhoneNumber { get; set; } = null!;

    }
}
