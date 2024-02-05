using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Models.CarPricingViewModels
{
    public class CarPricingVM
    {
        public CarPricingVM()
        {
            Amounts = new List<decimal>();
        }
        public string Model { get; set; }   
        public string Brand { get; set; }
        public List<Decimal> Amounts { get; set; }
        public string CoverImageUrl { get; set; }
    }
}
