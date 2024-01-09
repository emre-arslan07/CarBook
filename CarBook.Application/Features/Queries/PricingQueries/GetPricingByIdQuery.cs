using CarBook.Application.Features.Results.PricingResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.PricingQueries
{
    public class GetPricingByIdQuery:IRequest<GetPricingByIdQueryResult>
    {
        public GetPricingByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
