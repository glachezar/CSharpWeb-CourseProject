namespace MyGarage.Data.Models
{


    public class JobCardPart
    {
        public Guid PartId { get; set; }
        public Part Part { get; set; }

        public Guid JobCardId { get; set; }
        public JobCard JobCard { get; set; }
    }
}
