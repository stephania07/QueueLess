using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace QueueLess.Models
{
    public class QueueDbContext : DbContext
    {
        public DbSet<Queue> Queues { get; set; }
    }
}