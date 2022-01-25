using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.Model;
using System;
using System.Collections.Generic;

namespace Db.SQL.Configuration
{
    public class TrainerConfiguration : IEntityTypeConfiguration<Trainer>
    {
        public static List<Trainer> collection = new List<Trainer>()
        {
            new Trainer
            {
                Id = Guid.NewGuid(),
                FirstName = "Renata",
                LastName = "Bieżnia",
                eMail = "renatabieznia@athlead.com",
                Type = MVC.Helpers.EmployeeType.trainer
            },
            new Trainer
            {
                Id = Guid.NewGuid(),
                FirstName = "Jan",
                LastName = "Ciężarek",
                eMail = "janciezarek@athlead.com",
                Type = MVC.Helpers.EmployeeType.trainer
            }
        };

        public void Configure(EntityTypeBuilder<Trainer> builder)
        {
            builder.ToTable("Trainer");

            //trener ma wielu zawodnikow, ktorzy maja jednego trenera
            builder
                .HasMany(t => t.Athletes)
                .WithOne(a => a.Trainer)
                .HasForeignKey(k => k.Id);
            builder
                .HasMany(c => c.Competition)
                .WithOne(a => a.Trainer)
                .HasForeignKey(k=>k.Id);
            builder
                .HasOne(t => t.Club)
                .WithOne(c => c.Trainer);
            //builder
            //    .HasMany(t => t.Messages)
            //    .HasOne(m => m.);

            builder.HasData(collection);
        }
    }
}
