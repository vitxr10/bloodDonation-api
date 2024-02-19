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
    public class DonationConfiguration : IEntityTypeConfiguration<Donation>
    {
        public void Configure(EntityTypeBuilder<Donation> builder)
        {
            builder.HasKey(dn => dn.Id);

            builder.ToTable("Donations");

            builder.HasOne(dn => dn.Donor)
                .WithMany(d => d.Donations)
                .HasForeignKey(dn => dn.DonorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
