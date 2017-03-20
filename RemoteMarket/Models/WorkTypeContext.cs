using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RemoteMarket.Models
{
    public class WorkTypeContext : DbContext
    {
        public DbSet<WorkType> WorkTypes { get; set; }
    }
}