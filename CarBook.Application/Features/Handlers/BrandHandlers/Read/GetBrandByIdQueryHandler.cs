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
    public class GetBrandByIdQueryHandler : IRequestHandler<GetBrandByIdQuery, GetBrandByIdQueryResult>
    {
        private readonly IRepository<Brand> _repository;

        public GetBrandByIdQueryHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task<GetBrandByIdQueryResult> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken)
        {
            var query = await _repository.Get(request.Id);
            if (query != null)
            {
            return new GetBrandByIdQueryResult
            {
                Id = query.ID,
                Name = query.Name

            };

            }
            else
            {
                return null;
            }
        }
    }
}
