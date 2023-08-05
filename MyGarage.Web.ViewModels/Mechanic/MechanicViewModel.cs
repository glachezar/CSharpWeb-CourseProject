namespace MyGarage.Web.ViewModels.Mechanic
{
    using System.ComponentModel.DataAnnotations;

    using static MyGarage.Common.EntityValidationConstants.Mechanic;

    public class MechanicViewModel
    {

        public string Id { get; set; } = null!;


        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;


        [StringLength(SurnameMaxLength, MinimumLength = SurnameMinLength)] 
        public string Surname { get; set; } = null!;


        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength)] 
        public string PhoneNumber { get; set; } = null!;
    }
}
