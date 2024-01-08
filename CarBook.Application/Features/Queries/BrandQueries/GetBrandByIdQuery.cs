using CarBook.Application.Features.Results.BrandResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.BrandQueries
{
    public class GetBrandByIdQuery:IRequest<GetBrandByIdQueryResult>
    {
        public GetBrandByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
