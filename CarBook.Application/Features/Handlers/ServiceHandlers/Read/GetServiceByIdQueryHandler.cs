using CarBook.Application.Features.Queries.ServiceQueries;
using CarBook.Application.Features.Results.PricingResults;
using CarBook.Application.Features.Results.ServiceResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Handlers.ServiceHandlers.Read
{
    public class GetServiceByIdQueryHandler : IRequestHandler<GetServiceByIdQuery, GetServiceByIdQueryResult>
    {
        private readonly IRepository<Service> _repository;

        public GetServiceByIdQueryHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task<GetServiceByIdQueryResult> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var query = await _repository.Get(request.Id);
            if (query != null)
            {
                return new GetServiceByIdQueryResult
                {
                    Id = query.ID,
                   Title = query.Title,
                   Description = query.Description,
                   IconUrl = query.IconUrl
                };

            }
            else
            {
                return null;
            }
        }
    }
}
