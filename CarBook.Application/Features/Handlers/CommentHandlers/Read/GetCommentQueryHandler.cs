using CarBook.Application.Features.Queries.CommentQueries;
using CarBook.Application.Features.Results.CommentResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Handlers.CommentHandlers.Read
{
    public class GetCommentQueryHandler : IRequestHandler<GetCommentQuery, List<GetCommentQueryResult>>
    {
        private readonly IRepository<Comment> _repository;

        public GetCommentQueryHandler(IRepository<Comment> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCommentQueryResult>> Handle(GetCommentQuery request, CancellationToken cancellationToken)
        {
            var query = await _repository.GetList();
            return query.Select(x=>new GetCommentQueryResult
            {
                BlogId = x.BlogId,
                CreatedDate = x.CreatedDate,
                Description = x.Description,
                Id=x.ID,
                Name=x.Name
            }).ToList();
        }
    }
}
