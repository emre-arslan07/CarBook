using CarBook.Application.Features.Queries.CarPricingQueries;
using CarBook.Application.Features.Results.CarPricingResults;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Handlers.CarPricingHandlers.Read
{
    public class GetCarPricingWithCarQueryHandler : IRequestHandler<GetCarPricingWithCarQuery, List<GetCarPricingWithCarQueryResult>>
    {
        private readonly ICarPricingRepository _carPricingRepository;

        public GetCarPricingWithCarQueryHandler(ICarPricingRepository carPricingRepository)
        {
            _carPricingRepository = carPricingRepository;
        }

        public async Task<List<GetCarPricingWithCarQueryResult>> Handle(GetCarPricingWithCarQuery request, CancellationToken cancellationToken)
        {
            //var query = await _carPricingRepository.GetCarPricingWithCars();
            //return query.Select(x=>new GetCarPricingQueryResult 
            //{
            //    CarId=x.CarId,
            //    Amount=x.Amount,
            //    Brand=x.Car.Brand.Name,
            //    CoverImageUrl=x.Car.CoverImageUrl,
            //    Id=x.CarId,
            //    Model=x.Car.Model
            //}).ToList();

            var query = await _carPricingRepository.GetCarPricingWithCars();
            return query.Select(x => new GetCarPricingWithCarQueryResult
            {
                CarId = x.CarId,
                Amount = x.Amount,
                Brand = x.Car.Brand.Name,
                CoverImageUrl = x.Car.CoverImageUrl,
                Id = x.ID,
                Model = x.Car.Model,
                PricingName=x.Pricing.Name
            }).ToList();
        }
    }
}
