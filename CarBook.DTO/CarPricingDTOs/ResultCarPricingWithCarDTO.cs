using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.DTO.CarPricingDTOs
{
    public class ResultCarPricingWithCarDTO
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal Amount { get; set; }
        public string CoverImageUrl { get; set; }
        public string PricingName { get; set; }
    }
}
