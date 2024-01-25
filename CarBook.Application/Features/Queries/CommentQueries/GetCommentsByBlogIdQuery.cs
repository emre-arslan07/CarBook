using CarBook.Application.Features.Results.CommentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.CommentQueries
{
    public class GetCommentsByBlogIdQuery:IRequest<List<GetCommentsByBlogIdQueryResult>>
    {
        public GetCommentsByBlogIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
