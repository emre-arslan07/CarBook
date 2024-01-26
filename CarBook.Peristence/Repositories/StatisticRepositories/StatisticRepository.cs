using CarBook.Application.Interfaces.StatisticInterfaces;
using CarBook.Domain.Entities;
using CarBook.Peristence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Peristence.Repositories.StatisticRepositories
{
    public class StatisticRepository : IStatisticRepository
    {
        private readonly CarBookDbContext _context;

        public StatisticRepository(CarBookDbContext context)
        {
            _context = context;
        }

        public int GetAuthorCount()
        {
            return _context.Authors.Count();
        }

        public decimal GetAvgRentPriceForDaily()
        {
            return _context.CarPricings.Where(x => x.Pricing.Name == "Günlük").Average(x => x.Amount);
           
        }

        public decimal GetAvgRentPriceForMonthly()
        {
            return _context.CarPricings.Where(x => x.Pricing.Name == "Aylık").Average(x => x.Amount);
        }

        public decimal GetAvgRentPriceForWeekly()
        {
            return _context.CarPricings.Where(x => x.Pricing.Name == "Haftalık").Average(x => x.Amount);
        }

        public int GetBlogCount()
        {
            return _context.Blogs.Count();
        }

        public string GetBlogTitleByMaxBlogComment()
        {
            throw new NotImplementedException();
        }

        public int GetBrandCount()
        {
            return _context.Brands.Count();
        }

        public string GetBrandNameByMaxCar()
        {
            throw new NotImplementedException();
        }

        public string GetCarBrandAndModelByRentPriceDailyMax()
        {
            throw new NotImplementedException();
        }

        public string GetCarBrandAndModelByRentPriceDailyMin()
        {
            throw new NotImplementedException();
        }

        public int GetCarCount()
        {
            return _context.Cars.Count();
        }

        public int GetCarCountByFuelElectric()
        {
            return _context.Cars.Where(x => x.Fuel == "Elektrik").Count();
        }

        public int GetCarCountByFuelGasolineOrDiesel()
        {
            return _context.Cars.Where(x => x.Fuel == "Benzin" || x.Fuel == "Dizel").Count();
        }

        public int GetCarCountByKmSmallerThen1000()
        {
            return _context.Cars.Where(x=>x.Km<1000).Count();
        }

        public int GetCarCountByTranmissionIsAuto()
        {
           return _context.Cars.Where(x=>x.Transmission=="Otomatik").Count();
        }

        public int GetLocationCount()
        {
            return _context.Locations.Count();
        }
    }
}
