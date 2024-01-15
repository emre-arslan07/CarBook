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
	public class UpdateTestimonialCommandHandler : IRequestHandler<UpdateTestimonialCommand, bool>
	{
		private readonly IRepository<Testimonial> _repository;

		public UpdateTestimonialCommandHandler(IRepository<Testimonial> repository)
		{
			_repository = repository;
		}

		public async Task<bool> Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
		{
			return await _repository.Update(new Testimonial
			{
				ID = request.Id,
				Name = request.Name,
				Comment = request.Comment,
				ImageUrl = request.ImageUrl,
				Title = request.Title
			});
		}
	}
}
