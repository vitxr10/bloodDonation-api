using BloodDonation.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonation.Infrastructure.Persistence.Configurations
{
    public class DonorConfiguration : IEntityTypeConfiguration<Donor>
    {
        public void Configure(EntityTypeBuilder<Donor> builder)
        {
            builder.HasKey(d => d.Id);

            builder.ToTable("Donors");

            builder.HasMany(d => d.Donations)
                .WithOne(dn => dn.Donor)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.Address)
                .WithOne(a => a.Donor)
                .HasForeignKey<Address>(a => a.DonorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
