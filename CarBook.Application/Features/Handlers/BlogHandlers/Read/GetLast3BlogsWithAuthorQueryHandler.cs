using CarBook.Application.Features.Queries.BlogQueries;
using CarBook.Application.Features.Results.BlogResults;
using CarBook.Application.Interfaces.BlogRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Handlers.BlogHandlers.Read
{
    public class GetLast3BlogsWithAuthorQueryHandler : IRequestHandler<GetLast3BlogsWithAuthorQuery, List<GetLast3BlogsWithAuthorQueryResult>>
    {
        private readonly IBlogRepository _repository;

        public GetLast3BlogsWithAuthorQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetLast3BlogsWithAuthorQueryResult>> Handle(GetLast3BlogsWithAuthorQuery request, CancellationToken cancellationToken)
        {
            var query = await _repository.GetLast3BlogWithAuthor();
            return query.Select(x=>new GetLast3BlogsWithAuthorQueryResult
            {
                AuthorId = x.AuthorId,
                CategoryId = x.CategoryId,
                CoverImageUrl = x.CoverImageUrl,
                CreatedDate = x.CreatedDate,
                Id=x.ID,
                Title=x.Title,
                AuthorName=x.Author.Name
            }).ToList();
        }
    }
}
