using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Db.SQL.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public static List<User> collection = new List<User>()
        { 
            new User
            {
                Id = Guid.NewGuid(),
                EmployeeId = TrainerConfiguration.collection.First().Id,
                Username = "test123",
                Password = "test456"
            },
            new User
            {
                Id = Guid.NewGuid(),
                EmployeeId = AthleteConfiguration.collection.First().Id,
                Username = "123",
                Password = "456"
            }
        };

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            //trener ma wielu zawodnikow, ktorzy maja jednego trenera
            builder
                .HasOne(t => t.Employee)
                .WithOne(a => a.User);

            builder.HasData(collection);
        }
    }
}
