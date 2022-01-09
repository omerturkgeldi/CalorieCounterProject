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
    public class FoodConfiguration : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> builder)
        {
            builder.HasKey(x => x.FoodId);
            builder.Property(x => x.FoodId).UseIdentityColumn();
            builder.HasIndex(x => x.UrlName).IsUnique();
            builder.Property(x => x.FoodName).IsRequired();
            builder.Property(x => x.Kcal).IsRequired();

            builder.ToTable("Foods");

        }
    }
}
