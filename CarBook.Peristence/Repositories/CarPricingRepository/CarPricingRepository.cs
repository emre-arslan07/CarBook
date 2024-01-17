using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Domain.Entities;
using CarBook.Peristence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Peristence.Repositories.CarPricingRepository
{
    public class CarPricingRepository : ICarPricingRepository
    {
        private readonly CarBookDbContext _context;

        public CarPricingRepository(CarBookDbContext context)
        {
            _context = context;
        }

        public async Task<List<CarPricing>> GetCarPricingWithCars()
        {
            return await _context.CarPricings.Include(x => x.Pricing).Include(y => y.Car).ThenInclude(z => z.Brand).Where(x=>x.Pricing.Name=="Günlük").ToListAsync();
            //return await _context.CarPricings.Include(x=>x.Car).ThenInclude(y=>y.Brand).Include(z=>z.Pricing).ToListAsync();
        }
    }
}
