using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.Model;
using System;
using System.Collections.Generic;

namespace Db.SQL.Configuration
{
    public class AthleteConfiguration : IEntityTypeConfiguration<Athlete>
    {
        public static List<Athlete> collection = new List<Athlete>()
        {
            new Athlete
            {
                Id = Guid.NewGuid(),
                FirstName = "Ewelina",
                LastName = "Skoczna",
                eMail = "ewelinaskoczna@athlead.com",
                Type = MVC.Helpers.EmployeeType.athlete
            },
            new Athlete
            {
                Id = Guid.NewGuid(),
                FirstName = "Dawid",
                LastName = "Bicepsik",
                eMail = "dawidbicepsik@athlead.com",
                Type = MVC.Helpers.EmployeeType.athlete
            }
        };

        public void Configure(EntityTypeBuilder<Athlete> builder)
        {
            builder.ToTable("Athlete");

            //zawodnik ma jednego trenera ale trener ma wielu zawodnikow
            builder
                .HasOne(a => a.Trainer)
                .WithMany(t=>t.Athletes);
            
            builder.HasData(collection);
        }
    }
}
