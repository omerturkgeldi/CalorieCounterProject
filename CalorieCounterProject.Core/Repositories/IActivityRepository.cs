using CalorieCounterProject.Core.DTOs;
using CalorieCounterProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounterProject.Core.Repositories
{
    public interface IActivityRepository : IRepository<Activity>
    {

        Task<List<ActivityDto>> SearchByActivityName(string name);



    }
}
