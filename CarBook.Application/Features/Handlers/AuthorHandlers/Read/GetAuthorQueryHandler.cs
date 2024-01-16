using CarBook.Application.Features.Queries.AuthorQueries;
using CarBook.Application.Features.Results.AuthorResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Handlers.AuthorHandlers.Read
{
    public class GetAuthorQueryHandler : IRequestHandler<GetAuthorQuery, List<GetAuthorQueryResult>>
    {
        private readonly IRepository<Author> _repository;

        public GetAuthorQueryHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAuthorQueryResult>> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
        {
            var query = await _repository.GetList();
            return query.Select(x => new GetAuthorQueryResult
            {
                Id = x.ID,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                Name = x.Name
            }).ToList();
        }
    }
}
