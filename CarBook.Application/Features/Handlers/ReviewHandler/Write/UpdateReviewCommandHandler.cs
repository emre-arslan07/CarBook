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
	public class UpdateReviewCommandHandler : IRequestHandler<UpdateReviewCommand, bool>
	{
		private readonly IRepository<Review> _repository;

		public UpdateReviewCommandHandler(IRepository<Review> repository)
		{
			_repository = repository;
		}

		public async Task<bool> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
		{
			return await _repository.Update(new Review
			{
				CarId = request.CarId,
				CustomerComment = request.CustomerComment,
				CustomerName = request.CustomerName,
				CustomerImage = request.CustomerImage,
				RaytingValue = request.RaytingValue,
				ReviewDate = request.ReviewDate,
				ID=request.Id
			});
		}
	}
}
