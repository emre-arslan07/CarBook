using CarBook.Application.Features.Queries.ServiceQueries;
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
    public class GetServiceQueryHandler : IRequestHandler<GetServiceQuery, List<GetServiceQueryResult>>
    {
        private readonly IRepository<Service> _repository;

        public GetServiceQueryHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetServiceQueryResult>> Handle(GetServiceQuery request, CancellationToken cancellationToken)
        {
            var query = await _repository.GetList();
            return query.Select(x=>new GetServiceQueryResult
            {
                Id=x.ID,
                Description=x.Description,
                IconUrl=x.IconUrl,
                Title=x.Title
            }).ToList();
        }
    }
}
