using CarBook.Application.Features.Queries.CarQueries;
using CarBook.Application.Features.Results.CarResults;
using CarBook.Application.Interfaces.CarInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Handlers.CarHandlers.Read
{
    public class GetLast5CarsWithBrandQueryHandler : IRequestHandler<GetLast5CarsWithBrandQuery, List<GetLast5CarsWithBrandQueryResult>>
    {
        private readonly ICarRepository _carRepository;

        public GetLast5CarsWithBrandQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<List<GetLast5CarsWithBrandQueryResult>> Handle(GetLast5CarsWithBrandQuery request, CancellationToken cancellationToken)
        {
            var query = await _carRepository.GetLast5CarsListWithBrand();
            return query.Select(x => new GetLast5CarsWithBrandQueryResult
            {
                BigImageUrl = x.BigImageUrl,
                BrandId = x.BrandId,
                BrandName=x.Brand.Name,
                CoverImageUrl=x.CoverImageUrl,
                Fuel=x.Fuel,
                Id=x.ID,
                Km=x.Km,
                Luggace=x.Luggace,
                Model = x.Model,
                Seat = x.Seat,
                Transmission = x.Transmission
            }).ToList();
        }
    }
}
