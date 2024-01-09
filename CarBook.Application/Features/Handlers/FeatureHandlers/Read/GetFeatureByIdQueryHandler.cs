using CarBook.Application.Features.Queries.FeatureQueries;
using CarBook.Application.Features.Results.FeatureResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Handlers.FeatureHandlers.Read
{
    public class GetFeatureByIdQueryHandler : IRequestHandler<GetFeatureByIdQuery, GetFeatureByIdQueryResult>
    {
        private readonly IRepository<Feature> _repository;

        public GetFeatureByIdQueryHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async Task<GetFeatureByIdQueryResult> Handle(GetFeatureByIdQuery request, CancellationToken cancellationToken)
        {
            var query=await _repository.Get(request.Id);
            if (query != null) { 
            return new GetFeatureByIdQueryResult
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
