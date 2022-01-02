using CalorieCounterProject.Core.Models;
using CalorieCounterProject.Data.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounterProject.Data
{
    public class AppDbContext:IdentityDbContext<UserApp, IdentityRole, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        }

        public DbSet<Food> Foods { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<DailyProductIntake> DailyProductIntakes { get; set; }
        public DbSet<DailyFoodIntake> DailyFoodIntakes { get; set; }
        public DbSet<DailyActivity> DailyActivities { get; set; }
        public DbSet<DailySteps> DailySteps { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<RelationshipType> RelationshipTypes { get; set; }
        public DbSet<Relationship> Relationships { get; set; }

        public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new FoodConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ActivityConfiguration());
            modelBuilder.ApplyConfiguration(new DailyProductIntakesConfiguration());
            modelBuilder.ApplyConfiguration(new DailyFoodIntakesConfiguration());
            modelBuilder.ApplyConfiguration(new DailyActivitiesConfiguration());
            modelBuilder.ApplyConfiguration(new DailyStepsConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new UserGroupConfiguration());
            modelBuilder.ApplyConfiguration(new RelationshipTypeConfiguration());
            modelBuilder.ApplyConfiguration(new RelationshipConfiguration());


            //modelBuilder.ApplyConfiguration(new ProductSeed(new int[] { 1, 2 }));

        }

    }
}
