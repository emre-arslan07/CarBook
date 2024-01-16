using CarBook.Application.Features.Queries.AuthorQueries;
using CarBook.Application.Features.Results.AuthorResults;
using CarBook.Application.Features.Results.BannerResults;
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
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, GetAuthorByIdQueryResult>
    {
        private readonly IRepository<Author> _repository;

        public GetAuthorByIdQueryHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public async Task<GetAuthorByIdQueryResult> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var query = await _repository.Get(request.Id);
            if (query != null)
            {
                return new GetAuthorByIdQueryResult
                {
                   Id = query.ID,
                   Description = query.Description,
                   ImageUrl= query.ImageUrl,
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
