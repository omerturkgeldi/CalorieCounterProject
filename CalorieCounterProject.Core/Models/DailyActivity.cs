using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounterProject.Core.Models
{
    public class DailyActivity
    {
        public int Id { get; set; }
        public int ActivityId { get; set; }
        public int Minutes { get; set; }
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }

    }
}
