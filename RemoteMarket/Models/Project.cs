namespace RemoteMarket.Models
{
    public class Project
    {
        //[ScaffoldColumn(false)]
        public int ProjectId { get; set; }

        public string UserId { get; set; }

        public int JobId { get; set; }

        public string Budget { get; set; }

        public string Subject { get; set; }

        public string Skills { get; set; }

        public string Description { get; set; }

        public int Duration { get; set; }

     }


    public class ProjectViewModel
    {
        public Project Project;
      
        public int JobName { get; set; }

        public int WorkName { get; set; }

        public string Duration { get; set; }

    }
}