using CarBook.Application.Features.Queries.BlogQueries;
using CarBook.Application.Features.Results.BlogResults;
using CarBook.Application.Features.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Handlers.BlogHandlers.Read
{
    public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, GetBlogByIdQueryResult>
    {
        private readonly IRepository<Blog> _repository;

        public GetBlogByIdQueryHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task<GetBlogByIdQueryResult> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var query = await _repository.Get(request.Id);
            if (query != null)
            {
                return new GetBlogByIdQueryResult
                {
                    AuthorId = query.AuthorId,
                    CategoryId= query.CategoryId,
                    CoverImageUrl = query.CoverImageUrl,
                    CreatedDate = query.CreatedDate,
                    Id = query.ID,
                    Title = query.Title,
                    Description= query.Description,
                    
                };

            }
            else
            {
                return null;
            }
        }
    }
}
