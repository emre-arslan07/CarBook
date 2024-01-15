using CarBook.Application.Features.Queries.TestimonialQueries;
using CarBook.Application.Features.Results.TestimonialResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Handlers.TestimonialHandlers.Read
{
	public class GetTestimonialQueryHandler : IRequestHandler<GetTestimonialQuery, List<GetTestimonialQueryResult>>
	{
		private readonly IRepository<Testimonial> _repository;

		public GetTestimonialQueryHandler(IRepository<Testimonial> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetTestimonialQueryResult>> Handle(GetTestimonialQuery request, CancellationToken cancellationToken)
		{
			var query = await _repository.GetList();
			return query.Select(x=> new GetTestimonialQueryResult 
			{ 
			Id=x.ID,
			Name=x.Name,
			Comment=x.Comment,
			ImageUrl=x.ImageUrl,
			Title=x.Title
			}).ToList();
		}
	}
}
