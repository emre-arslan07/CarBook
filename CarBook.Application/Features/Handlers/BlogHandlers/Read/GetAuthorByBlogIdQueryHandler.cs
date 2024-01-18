using CarBook.Application.Features.Queries.BlogQueries;
using CarBook.Application.Features.Results.BannerResults;
using CarBook.Application.Features.Results.BlogResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.BlogRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Handlers.BlogHandlers.Read
{
    public class GetAuthorByBlogIdQueryHandler : IRequestHandler<GetAuthorByBlogIdQuery, List<GetAuthorByBlogIdQueryResult>>
    {
        private readonly IBlogRepository _blogRepository;

        public GetAuthorByBlogIdQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<List<GetAuthorByBlogIdQueryResult>> Handle(GetAuthorByBlogIdQuery request, CancellationToken cancellationToken)
        {
            var query = await _blogRepository.GetAuthorByBlogId(request.Id);
           return query.Select(x=>new GetAuthorByBlogIdQueryResult
           {
               AuthorId = x.AuthorId,
               Id = x.ID,
               AuthorName = x.Author.Name,
               AuthorDescription = x.Author.Description,
               AuthorImageUrl = x.Author.ImageUrl,
           }).ToList();
        }
    }
}
