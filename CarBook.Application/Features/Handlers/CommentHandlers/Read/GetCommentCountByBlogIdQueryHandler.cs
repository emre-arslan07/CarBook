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
    public class GetCommentCountByBlogIdQueryHandler : IRequestHandler<GetCommentCountByBlogIdQuery, GetCommentCountByBlogIdQueryResult>
    {
        private readonly ICommentRepository _commentRepository;

        public GetCommentCountByBlogIdQueryHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public  async Task<GetCommentCountByBlogIdQueryResult> Handle(GetCommentCountByBlogIdQuery request, CancellationToken cancellationToken)
        {
            var query = await _commentRepository.GetCommentsCountByBlogId(request.Id);
            return new GetCommentCountByBlogIdQueryResult
            {
                CommentCount = query
            };
        }
    }
}
