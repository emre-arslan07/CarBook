using CarBook.Application.Features.Results.StatisticResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.StatisticQueries
{
    public class GetBrandCountQuery:IRequest<GetBrandCountQueryResult>
    {
    }
}
