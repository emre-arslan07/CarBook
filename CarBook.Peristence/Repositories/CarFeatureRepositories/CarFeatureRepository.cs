using CarBook.Application.Interfaces.CarFeatureInterfaces;
using CarBook.Domain.Entities;
using CarBook.Peristence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Peristence.Repositories.CarFeatureRepositories
{
    public class CarFeatureRepository : ICarFeatureRepository
    {
        private readonly CarBookDbContext _context;

        public CarFeatureRepository(CarBookDbContext context)
        {
            _context = context;
        }

        public async Task<List<CarFeature>> GetCarFeaturesByCarId(int id)
        {
            return await _context.CarFeatures.Include(x=>x.Feature).Where(y=>y.CarId == id).ToListAsync();
        }

        public Task<bool> UpdateCarFeatureAvailableChangeToFalse(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCarFeatureAvailableChangeToTrue(int id)
        {
            throw new NotImplementedException();
        }
    }
}
