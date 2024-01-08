using CarBook.Application.Features.Queries.CategoryQueries;
using CarBook.Application.Features.Results.CategoryResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Handlers.CategoryHandlers.Read
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, List<GetCategoryQueryResult>>
    {
        private readonly IRepository<Category> _repository;

        public GetCategoryQueryHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCategoryQueryResult>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var query = await _repository.GetList();
            return query.Select(x => new GetCategoryQueryResult
            {
                Id = x.ID,
                Name = x.Name
            }).ToList();
        }
    }
}
