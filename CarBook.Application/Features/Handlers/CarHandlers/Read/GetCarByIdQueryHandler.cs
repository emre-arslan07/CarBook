using CarBook.Application.Features.Queries.CarQueries;
using CarBook.Application.Features.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Handlers.CarHandlers.Read
{
    public class GetCarByIdQueryHandler : IRequestHandler<GetCarByIdQuery, GetCarByIdQueryResult>
    {
        private readonly IRepository<Car> _repository;

        public GetCarByIdQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
        {
            var query = await _repository.Get(request.Id);
            if (query != null)
            {
            return new GetCarByIdQueryResult
            {
                Id = query.ID,
                BigImageUrl = query.BigImageUrl,
                BrandId = query.BrandId,
                CoverImageUrl = query.CoverImageUrl,
                Fuel = query.Fuel,
                Km = query.Km,
                Luggace = query.Luggace,
                Model = query.Model,
                Seat = query.Seat,
                Transmission = query.Transmission,

            };

            }
            else
            {
                return null;
            }
        }
    }
}
