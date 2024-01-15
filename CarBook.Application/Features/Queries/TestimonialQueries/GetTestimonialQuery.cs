using CarBook.Application.Features.Results.TestimonialResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.TestimonialQueries
{
	public class GetTestimonialQuery:IRequest<List<GetTestimonialQueryResult>>
	{
	}
}
