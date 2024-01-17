using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Domain.Entities;
using CarBook.Peristence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Peristence.Repositories.CarRepositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarBookDbContext _context;

        public CarRepository(CarBookDbContext context)
        {
            _context = context;
        }

        public async Task<List<Car>> GetCarListWithBrand()
        {
            return await _context.Cars.Include(x => x.Brand).ToListAsync();
        }

        public async Task<List<Car>> GetLast5CarsListWithBrand()
        {
           return await _context.Cars.Include(x=>x.Brand).OrderByDescending(x => x.ID).Take(5).ToListAsync();
        }
    }
}
