using CarBook.Application.Features.Queries.BrandQueries;
using CarBook.Application.Features.Results.BrandResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Handlers.BrandHandlers.Read
{
    public class GetBrandQueryHandler : IRequestHandler<GetBrandQuery, List<GetBrandQueryResult>>
    {
        private readonly IRepository<Brand> _repository;

        public GetBrandQueryHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBrandQueryResult>> Handle(GetBrandQuery request, CancellationToken cancellationToken)
        {
            var query = await _repository.GetList();
            return query.Select(x=>new GetBrandQueryResult
            {
                Id=x.ID,
                Name=x.Name,
            }).ToList();
        }
    }
}
