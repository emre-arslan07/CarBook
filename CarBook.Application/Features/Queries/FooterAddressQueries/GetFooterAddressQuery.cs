using CarBook.Application.Features.Results.FooterAddressResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.FooterAddressQueries
{
    public class GetFooterAddressQuery:IRequest<List<GetFooterAddressQueryResult>>
    {
    }
}
