using System.Data.Entity;

namespace RemoteMarket.Models
{
    public class JobContext : DbContext
    {
        public DbSet<Job> JobTypes { get; set; }
    }
}