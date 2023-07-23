namespace MyGarage.Web.ViewModels.Part
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.Part;

    public class AllPartsViewModel
    {
        
        public string Id { get; set; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string PartName { get; set; } = null!;

        [Required]
        [StringLength(NumberMaxLength, MinimumLength = NumberMinLength)]
        public string PartNumber { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }
    }
}
