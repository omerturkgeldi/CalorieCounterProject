﻿using CalorieCounterProject.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounterProject.Data.Configurations
{
    public class DailyActivitiesConfiguration : IEntityTypeConfiguration<DailyActivity>
    {
        public void Configure(EntityTypeBuilder<DailyActivity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.ActivityId).IsRequired();
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.Date).IsRequired();

            builder.ToTable("DailyActivities");

        }
    }
}
