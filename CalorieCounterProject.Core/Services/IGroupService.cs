using CalorieCounterProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CalorieCounterProject.Core.Services
{
    public interface  IGroupService : IService<Group>
    {
        Task<Group> AddNewAsync(Group group);
    }
}
