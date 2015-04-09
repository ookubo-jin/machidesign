using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace matidesign.Models
{
    public class machidesignDBContext : DbContext
    {
        public System.Data.Entity.DbSet<matidesign.Models.Jichitai> jichitai { get; set; }
        public System.Data.Entity.DbSet<matidesign.Models.Group> group { get; set; }
        public System.Data.Entity.DbSet<matidesign.Models.Events> events { get; set; }

        public System.Data.Entity.DbSet<matidesign.Models.Machiaruki> machiaruki { get; set; }

        public System.Data.Entity.DbSet<matidesign.Models.MachiarukiData> machiarukiData { get; set; }

        public System.Data.Entity.DbSet<matidesign.Models.Account> account { get; set; }


    }
}