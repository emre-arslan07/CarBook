using CarBook.Application.Interfaces.StatisticInterfaces;
using CarBook.Domain.Entities;
using CarBook.Peristence.Context;
using Microsoft.EntityFrameworkCore;
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
            var values = _context.Comments.GroupBy(x => x.BlogId).
                Select(y => new
                {
                    BlogId = y.Key,
                    Count = y.Count(),
                }).OrderByDescending(z=>z.Count).Take(1).FirstOrDefault();
            var blogTitle=_context.Blogs.Where(x=>x.ID==values.BlogId).Select(x=>x.Title).FirstOrDefault();
            return blogTitle;
        }

        public int GetBrandCount()
        {
            return _context.Brands.Count();
        }

        public string GetBrandNameByMaxCar()
        {
            var values = _context.Cars.GroupBy(x => x.BrandId).
                Select(y => new
                {
                     BrandId=y.Key,
                     Count=y.Count()
                }).OrderByDescending(z=>z.Count).Take(1).FirstOrDefault();
            string brandName=_context.Brands.Where(x=>x.ID==values.BrandId).Select(y=>y.Name).FirstOrDefault();
            return brandName;
        }

        public string GetCarBrandAndModelByRentPriceDailyMax()
        {
            //Select * From CarPricings where Amount=(Select Max(Amount) From CarPricings where PricingID=3)
            int pricingId =_context.Pricings.Where(x => x.Name == "Günlük").Select(y => y.ID).FirstOrDefault();
            decimal amount = _context.CarPricings.Where(x => x.PricingId == pricingId).Max(x => x.Amount);
            int carId=_context.CarPricings.Where(x=>x.Amount==amount).Select(y=>y.CarId).FirstOrDefault();
            string brandModel=_context.Cars.Where(x=>x.ID==carId).Include(y=>y.Brand).Select(z=>z.Brand.Name +" "+z.Model).FirstOrDefault();
            return brandModel;
        }

        public string GetCarBrandAndModelByRentPriceDailyMin()
        {
            int pricingId = _context.Pricings.Where(x => x.Name == "Günlük").Select(y => y.ID).FirstOrDefault();
            decimal amount = _context.CarPricings.Where(x => x.PricingId == pricingId).Min(x => x.Amount);
            int carId = _context.CarPricings.Where(x => x.Amount == amount).Select(y => y.CarId).FirstOrDefault();
            string brandModel = _context.Cars.Where(x => x.ID == carId).Include(y => y.Brand).Select(z => z.Brand.Name + " " + z.Model).FirstOrDefault();
            return brandModel;
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
