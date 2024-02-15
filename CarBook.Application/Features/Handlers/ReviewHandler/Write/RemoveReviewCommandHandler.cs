using CarBook.Application.Features.Commands.ReviewCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Handlers.ReviewHandler.Write
{
	public class RemoveReviewCommandHandler : IRequestHandler<RemoveReviewCommand, bool>
	{
		private readonly IRepository<Review> _repository;

		public RemoveReviewCommandHandler(IRepository<Review> repository)
		{
			_repository = repository;
		}

		public async Task<bool> Handle(RemoveReviewCommand request, CancellationToken cancellationToken)
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
