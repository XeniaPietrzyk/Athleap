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
                FirstName = "Ewelina",
                LastName = "Bieżnia",
                eMail = "ewelinabieznia@athlead.com",
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

            //trener ma wielu zawodnikow ale zawodnik ma jednego trenera
            builder
                .HasMany(t => t.Athletes)
                .WithOne(a=>a.Trainer);
            
            builder.HasData(collection);
        }
    }
}
