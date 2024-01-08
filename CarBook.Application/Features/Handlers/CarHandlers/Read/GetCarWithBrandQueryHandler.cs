using CarBook.Application.Features.Queries.CarQueries;
using CarBook.Application.Features.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Handlers.CarHandlers.Read
{
    public class GetCarWithBrandQueryHandler : IRequestHandler<GetCarWithBrandQuery, List<GetCarWithBrandQueryResult>>
    {
        private readonly ICarRepository _carRepository;

        public GetCarWithBrandQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<List<GetCarWithBrandQueryResult>> Handle(GetCarWithBrandQuery request, CancellationToken cancellationToken)
        {
            var query =await _carRepository.GetCarListWithBrand();
            return query.Select(x => new GetCarWithBrandQueryResult
            {               
                BigImageUrl = x.BigImageUrl,
                BrandId = x.BrandId,
                CoverImageUrl = x.CoverImageUrl,
                Fuel = x.Fuel,
                Id = x.ID,
                Km = x.Km,
                Luggace = x.Luggace,
                Model = x.Model,
                Seat = x.Seat,
                Transmission = x.Transmission,
                BrandName=x.Brand.Name
            }).ToList();
        }
    }
}
