using CarBook.Application.Features.Results.BlogResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.BlogQueries
{
    public class GetLast3BlogsWithAuthorQuery:IRequest<List<GetLast3BlogsWithAuthorQueryResult>>
    {
    }
}
