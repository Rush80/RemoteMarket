namespace RemoteMarket.Models
{
    public class Job
    {
        //[ScaffoldColumn(false)]
        public int JobId { get; set; }

        public string Name { get; set; }

        public int WorkTypeId { get; set; }
    }
}