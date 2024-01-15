using CarBook.Application.Features.Commands.TestimonialCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Handlers.TestimonialHandlers.Write
{
	public class CreateTestimonialCommandHandler : IRequestHandler<CreateTestimonialCommand, bool>
	{
		private readonly IRepository<Testimonial> _repository;

		public CreateTestimonialCommandHandler(IRepository<Testimonial> repository)
		{
			_repository = repository;
		}

		public async Task<bool> Handle(CreateTestimonialCommand request, CancellationToken cancellationToken)
		{
			return await _repository.AddAsync(new Testimonial
			{
				Comment = request.Comment,
				ImageUrl = request.ImageUrl,
				Name = request.Name,
				Title = request.Title
			});
		}
	}
}
