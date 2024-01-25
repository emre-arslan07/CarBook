using CarBook.Application.Features.Queries.CommentQueries;
using CarBook.Application.Features.Results.CommentResults;
using CarBook.Application.Interfaces.CommentInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Handlers.CommentHandlers.Read
{
    public class GetCommentsByBlogIdQueryHandler : IRequestHandler<GetCommentsByBlogIdQuery, List<GetCommentsByBlogIdQueryResult>>
    {
        private readonly ICommentRepository _commentRepository;

        public GetCommentsByBlogIdQueryHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<List<GetCommentsByBlogIdQueryResult>> Handle(GetCommentsByBlogIdQuery request, CancellationToken cancellationToken)
        {
            var query = await _commentRepository.GetCommentsByBlogId(request.Id);
            return query.Select(x => new GetCommentsByBlogIdQueryResult
            {
                BlogId = x.BlogId,
                Id = x.ID,
                CreatedDate = x.CreatedDate,
                Description = x.Description,
                Name = x.Name
            }).ToList();

        }
    }
}
