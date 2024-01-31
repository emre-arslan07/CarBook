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
    public class GetCarWithBrandByIdQueryHandler : IRequestHandler<GetCarWithBrandByIdQuery, GetCarWithBrandByIdQueryResult>
    {
        private readonly ICarRepository _carRepository;

        public GetCarWithBrandByIdQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<GetCarWithBrandByIdQueryResult> Handle(GetCarWithBrandByIdQuery request, CancellationToken cancellationToken)
        {
            var query = await _carRepository.GetCarWithBrandAsync(x=>x.ID==request.Id);
            return new GetCarWithBrandByIdQueryResult
            {
                Id = query.ID,
                BigImageUrl = query.BigImageUrl,
                BrandId = query.BrandId,
                BrandName = query.Brand.Name,
                CoverImageUrl = query.CoverImageUrl,
                Fuel = query.Fuel,
                Km = query.Km,
                Luggace = query.Luggace,
                Model = query.Model,
                Seat = query.Seat,
                Transmission = query.Transmission

            };

        }
    }
}
