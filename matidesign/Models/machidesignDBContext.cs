using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace matidesign.Models
{
    public class machidesignDBContext : DbContext
    {
        public DbSet<Jichitai> jichitai { get; set; }

    }
}