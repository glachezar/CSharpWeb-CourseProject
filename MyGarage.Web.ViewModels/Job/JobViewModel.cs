namespace MyGarage.Web.ViewModels.Job
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Job;

    public class JobViewModel
    {
        public string Id { get; set; } = null!;

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string JobName { get; set; } = null!;

        [Required]
        [Range(typeof(decimal), PriceMinValue, PriceMaxValue)]
        public decimal Price { get; set; }
    }
}
