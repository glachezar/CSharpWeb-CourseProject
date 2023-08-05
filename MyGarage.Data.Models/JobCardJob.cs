namespace MyGarage.Data.Models
{


    public class JobCardJob
    {
        public Guid JobId { get; set; }
        public Job Job { get; set; }

        public Guid JobCardId { get; set; }
        public JobCard JobCard { get; set; }
    }
}
