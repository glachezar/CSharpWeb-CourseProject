namespace MyGarage.Web.ViewModels.Part
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.Part;

    public class AllPartsViewModel
    {

        public string? Id { get; set; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        [Display(Name = "Part Name")]
        public string PartName { get; set; } = null!;

        [Required]
        [StringLength(NumberMaxLength, MinimumLength = NumberMinLength)]
        [Display(Name = "Part Number")]
        public string PartNumber { get; set; } = null!;

        [Required]
        [Range(typeof(decimal), PriceMinValue, PriceMaxValue)]
        public decimal Price { get; set; }
    }
}
