
using Microsoft.EntityFrameworkCore;
using OtoSoft.Plant.DataAccess.Concrete.Maps;
using OtoSoft.Plant.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoSoft.Plant.DataAccess.Concrete.Contexts
{
    public class HerbContext : DbContext
    {
        public HerbContext(DbContextOptions<HerbContext> options) : base(options)
        {

        }
        public DbSet<Herb> Herbs { get; set; }
        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<ComplaintHerb> ComplaintHerbs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ComplaintMap());
            modelBuilder.ApplyConfiguration(new HerbMap());
            modelBuilder.Entity<ComplaintHerb>().HasKey("HerbId","ComplaintId");
                
                
        }
        

    }
}
