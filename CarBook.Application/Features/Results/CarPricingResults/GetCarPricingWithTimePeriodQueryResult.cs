﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Results.CarPricingResults
{
    public class GetCarPricingWithTimePeriodQueryResult
    {
        //public string Brand { get; set; }
        public string BrandModel { get; set; }
        public decimal DailyAmount { get; set; }
        public decimal WeeklyAmount { get; set; }
        public decimal MonthlyAmount { get; set; }
        public string CoverImageUrl { get; set;}
    }
}
