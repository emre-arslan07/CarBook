using CarBook.Application.Models.CarPricingViewModels;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.CarPricingInterfaces
{
    public interface ICarPricingRepository
    {
        Task<List<CarPricing>> GetCarPricingWithCars();
       List<CarPricingVM> GetCarPricingWithTimePeriod();
    }
}
