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
    public class GetBlogWithAuthorQueryHandler : IRequestHandler<GetBlogWithAuthorQuery, List<GetBlogWithAuthorQueryResult>>
    {
        private readonly IBlogRepository _blogRepository;

        public GetBlogWithAuthorQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<List<GetBlogWithAuthorQueryResult>> Handle(GetBlogWithAuthorQuery request, CancellationToken cancellationToken)
        {
            var query = await _blogRepository.GetBlogWithAuthor();
            return query.Select(x => new GetBlogWithAuthorQueryResult
            {
                AuthorId = x.AuthorId,
                AuthorName=x.Author.Name,
                CategoryId=x.CategoryId,
                CoverImageUrl=x.CoverImageUrl,
                CreatedDate = x.CreatedDate,
                Id=x.ID,
                Title=x.Title,
                Description=x.Description,
                AuthorDescription=x.Description,
                AuthorImageUrl=x.Author.ImageUrl,
                //CategoryName=x.Category.Name
            }).ToList();
        }
    }
}
