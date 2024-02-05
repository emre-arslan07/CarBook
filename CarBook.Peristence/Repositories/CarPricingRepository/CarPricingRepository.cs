using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Application.Models.CarPricingViewModels;
using CarBook.Domain.Entities;
using CarBook.Peristence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public List<CarPricingVM> GetCarPricingWithTimePeriod()
        {
            List<CarPricingVM> values = new List<CarPricingVM>();
            using(var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "Select * From (Select Name,Model,CoverImageUrl,PricingID,Amount From CarPricings Inner Join Cars On Cars.ID=CarPricings.CarId Inner Join Brands On Brands.ID=Cars.BrandID) As SourceTable Pivot (Sum(Amount) For PricingID In ([3],[4],[5])) as PivotTable;";  
                command.CommandType = System.Data.CommandType.Text;
                _context.Database.OpenConnection(); 
                using (var reader = command.ExecuteReader()) 
                { 
                    while (reader.Read())
                    {
                        CarPricingVM carPricingViewModel = new CarPricingVM()
                        {
                            Brand = reader["Name"].ToString(),
                            Model= reader["Model"].ToString(),
                            CoverImageUrl = reader["CoverImageUrl"].ToString(),
                            Amounts = new List<decimal>
                            {
                                Convert.ToDecimal(reader[3]),
                                Convert.ToDecimal(reader[4]),
                                Convert.ToDecimal(reader[5])
                            }
                        };
                        values.Add(carPricingViewModel);
                    }
                }
                _context.Database.CloseConnection();
                return values;
            }


        }
       


    }
}
