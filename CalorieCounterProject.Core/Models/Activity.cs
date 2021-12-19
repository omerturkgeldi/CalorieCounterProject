using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounterProject.Core.Models
{
    public class Activity
    {
        public int ActivityId { get; set; }
        public string ActivityName { get; set; }
        public string SpecificMotion { get; set; }
        public float METValue { get; set; }
        public DateTime RegisterDate { get; set; }
        public string Note { get; set; }
        public bool IsDeleted { get; set; }
    }
}
