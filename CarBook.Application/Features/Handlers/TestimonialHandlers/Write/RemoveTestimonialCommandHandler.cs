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
	public class RemoveTestimonialCommandHandler : IRequestHandler<RemoveTestimonialCommand, bool>
	{
		private readonly IRepository<Testimonial> _repository;

		public RemoveTestimonialCommandHandler(IRepository<Testimonial> repository)
		{
			_repository = repository;
		}

		public async Task<bool> Handle(RemoveTestimonialCommand request, CancellationToken cancellationToken)
		{
			var query = await _repository.Get(request.Id);
			if (query == null)
			{
				return false;
			}
			else
			{
				if (await _repository.Remove(query) == true)
				{
					return true;
				}
				else { return false; }
			}
		}
	}
}
