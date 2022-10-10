using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OtoSoft.Plant.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoSoft.Plant.DataAccess.Concrete.Maps
{
    public class ComplaintMap : IEntityTypeConfiguration<Complaint>
    {
        public void Configure(EntityTypeBuilder<Complaint> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Description).HasMaxLength(1000).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(150).IsRequired();

            builder.HasMany(x => x.ComplaintHerbs).WithOne(x => x.Complaint).HasForeignKey(x=>x.ComplaintId).HasPrincipalKey(y=>y.Id);
        }
    }
}
