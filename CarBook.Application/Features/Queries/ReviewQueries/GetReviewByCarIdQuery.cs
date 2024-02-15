using CarBook.Application.Features.Results.ReviewResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.ReviewQueries
{
	public class GetReviewByCarIdQuery:IRequest<List<GetReviewByCarIdQueryResult>>
	{
		public GetReviewByCarIdQuery(int id)
		{
			Id = id;
		}

		public int Id { get; set; }
    }
}
