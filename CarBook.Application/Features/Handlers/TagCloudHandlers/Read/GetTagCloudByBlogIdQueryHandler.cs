using CarBook.Application.Features.Queries.TagCloudQueries;
using CarBook.Application.Features.Results.TagCloudResults;
using CarBook.Application.Interfaces.TagCloudInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Handlers.TagCloudHandlers.Read
{
    public class GetTagCloudByBlogIdQueryHandler : IRequestHandler<GetTagCloudByBlogIdQuery, List<GetTagCloudByBlogIdQueryResult>>
    {
        private readonly ITagCloudRepository _tagCloudRepository;

        public GetTagCloudByBlogIdQueryHandler(ITagCloudRepository tagCloudRepository)
        {
            _tagCloudRepository = tagCloudRepository;
        }

        public async Task<List<GetTagCloudByBlogIdQueryResult>> Handle(GetTagCloudByBlogIdQuery request, CancellationToken cancellationToken)
        {
            var query = await _tagCloudRepository.GetTagCloudsByBlogId(request.Id);
            return query.Select(x=>new GetTagCloudByBlogIdQueryResult
            {
                Id=x.ID,
                BlogId=x.BlogId,
                Title=x.Title,
            }).ToList();
        }
    }
}
