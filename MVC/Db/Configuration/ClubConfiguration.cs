using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.Model;
using System;
using System.Collections.Generic;

namespace Db.SQL.Configuration
{
    public class ClubConfiguration : IEntityTypeConfiguration<Club>
    {
        public static List<Club> collection = new List<Club>()
        {};

        public void Configure(EntityTypeBuilder<Club> builder)
        {
            builder.ToTable("Club");

            builder
                .HasMany(c => c.Athletes)
                .WithOne(a => a.Club)
                .HasForeignKey(k => k.Id);
            builder
                .HasOne(c => c.Trainer)
                .WithOne(t => t.Club);

            builder.HasData(collection);
        }
    }
}
