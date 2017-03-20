using System.Data.Entity;

namespace RemoteMarket.Models
{
    public class ProjectContext : DbContext
    {
        public DbSet<Project> JobTypes { get; set; }
    }
}