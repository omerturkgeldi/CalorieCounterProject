using CalorieCounterProject.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounterProject.Data.Configurations
{
    public class DailyFoodIntakesConfiguration : IEntityTypeConfiguration<DailyFoodIntake>
    {
        public void Configure(EntityTypeBuilder<DailyFoodIntake> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.FoodId).IsRequired();
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.Date).IsRequired();

            builder.ToTable("DailyFoodIntakes");

        }
    }

}
