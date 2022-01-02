using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounterProject.Core.Models
{
    public class DailySteps
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int TotalSteps { get; set; }
        public DateTime Date { get; set; }

    }
}
