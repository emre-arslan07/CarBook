using CarBook.Application.Features.Results.BlogResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.BlogQueries
{
    public class GetAuthorByBlogIdQuery:IRequest<List<GetAuthorByBlogIdQueryResult>>
    {
        public GetAuthorByBlogIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
