using CarBook.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class Car:BaseEntity
    {
        public string Model { get; set; }
        public string CoverImageUrl { get; set; }
        public int Km { get; set; }
        public string Transmission { get; set; }
        public byte Seat { get; set; }
        public byte Luggace { get; set; }
        public string Fuel { get; set; }
        public string BigImageUrl { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public ICollection<CarFeature> CarFeatures { get; set; }
        public ICollection<CarDescription> CarDescriptions { get; set; }
        public ICollection<CarPricing> CarPricings { get; set; }
    }
}
