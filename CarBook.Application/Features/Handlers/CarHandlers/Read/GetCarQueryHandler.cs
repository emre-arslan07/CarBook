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
    public class GetCarQueryHandler : IRequestHandler<GetCarQuery, List<GetCarQueryResult>>
    {
        private readonly IRepository<Car> _repository;

        public GetCarQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarQueryResult>> Handle(GetCarQuery request, CancellationToken cancellationToken)
        {
            var query = await _repository.GetList();
            return query.Select(x=>new GetCarQueryResult
            {
                BigImageUrl = x.BigImageUrl,
                BrandId = x.BrandId,
                CoverImageUrl = x.CoverImageUrl,
                Fuel=x.Fuel,
                Id=x.ID,
                Km=x.Km,
                Luggace=x.Luggace,
                Model=x.Model,
                Seat=x.Seat,
                Transmission=x.Transmission
            }).ToList();
        }
    }
}
