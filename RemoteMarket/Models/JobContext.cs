using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RemoteMarket.Models
{
    public class JobContext : DbContext
    {
        public DbSet<Job> JobTypes { get; set; }
    }
}