using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.CarInterfaces
{
    public interface ICarRepository
    {
       Task<List<Car>> GetCarListWithBrand();
       Task<List<Car>> GetLast5CarsListWithBrand();
        Task<Car> GetCarWithBrandAsync(Expression<Func<Car, bool>> filter);
    }
}
