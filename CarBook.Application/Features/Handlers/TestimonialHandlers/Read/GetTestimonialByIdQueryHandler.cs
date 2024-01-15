using CarBook.Application.Features.Queries.TestimonialQueries;
using CarBook.Application.Features.Results.SocialMediaResults;
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
	public class GetTestimonialByIdQueryHandler : IRequestHandler<GetTestimonialByIdQuery, GetTestimonialByIdQueryResult>
	{
		private readonly IRepository<Testimonial> _repository;

		public GetTestimonialByIdQueryHandler(IRepository<Testimonial> repository)
		{
			_repository = repository;
		}

		public async Task<GetTestimonialByIdQueryResult> Handle(GetTestimonialByIdQuery request, CancellationToken cancellationToken)
		{
			var query = await _repository.Get(request.Id);
			if (query != null)
			{
				return new GetTestimonialByIdQueryResult
				{
					Id=query.ID,
					Comment=query.Comment,
					ImageUrl=query.ImageUrl,
					Name=query.Name,
					Title = query.Title
				};

			}
			else
			{
				return null;
			}
		}
	}
}
