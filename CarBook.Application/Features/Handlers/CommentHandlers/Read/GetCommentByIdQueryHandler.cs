using CarBook.Application.Features.Queries.CommentQueries;
using CarBook.Application.Features.Results.CategoryResults;
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
    public class GetCommentByIdQueryHandler : IRequestHandler<GetCommentByIdQuery, GetCommentByIdQueryResult>
    {
        private readonly IRepository<Comment> _repository;

        public GetCommentByIdQueryHandler(IRepository<Comment> repository)
        {
            _repository = repository;
        }

        public async Task<GetCommentByIdQueryResult> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var query = await _repository.Get(request.Id);
            if (query != null)
            {
                return new GetCommentByIdQueryResult
                {
                    Id = query.ID,
                    Name = query.Name,
                    BlogId = query.BlogId,
                    CreatedDate = query.CreatedDate,
                    Description = query.Description
                };

            }
            else
            {
                return null;
            }
        }
    }
}
