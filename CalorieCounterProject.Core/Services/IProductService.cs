using CalorieCounterProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounterProject.Core.Services
{
    public interface IProductService :IService<Product>
    {
        Task<Product> GetByNameAsync(string productName);
    }
}
