using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.Model;
using System;
using System.Collections.Generic;

namespace Db.SQL.Configuration
{
    public class CompetitionConfiguration : IEntityTypeConfiguration<Competition>
    {
        public static List<Competition> collection = new List<Competition>()
        {
            new Competition
            {
                Id = Guid.NewGuid(),
                Name = "Skok o tyczce",
                Description = "Zawody w skoku o tyczce dla kobiet.",
                Trainer = TrainerConfiguration.collection.Find(t=>t.LastName=="Ciężarek")
            },
            new Competition
            {
                Id = Guid.NewGuid(),
                Name = "Wspinaczka",
                Description = "Kwartalne ćwiczenia wspinaczkowe po ścianie  na czas.",
                Trainer = TrainerConfiguration.collection.Find(t=>t.LastName=="Ciężarek")
            }
        };

        public void Configure(EntityTypeBuilder<Competition> builder)
        {
            builder.ToTable("Competition");

            //zawodnik ma jednego trenera ale trener ma wielu zawodnikow
            builder
                .HasOne(c => c.Trainer)
                .WithMany(t => t.Competition)
                .HasForeignKey(k => k.Id);
            builder
                .HasMany(c => c.Athletes)
                .WithMany(a => a.Competition);

            builder.HasData(collection);
        }
    }
}
