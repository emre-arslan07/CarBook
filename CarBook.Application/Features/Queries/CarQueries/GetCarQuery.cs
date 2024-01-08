using CarBook.Application.Features.Results.CarResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.CarQueries
{
    public class GetCarQuery:IRequest<List<GetCarQueryResult>>
    {
    }
}
