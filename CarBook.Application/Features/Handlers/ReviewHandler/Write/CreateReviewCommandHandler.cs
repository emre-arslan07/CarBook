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
	public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand, bool>
	{
		private readonly IRepository<Review> _repository;

		public CreateReviewCommandHandler(IRepository<Review> repository)
		{
			_repository = repository;
		}

		public async Task<bool> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
		{
			return await _repository.AddAsync(new Review
			{
				CarId = request.CarId,
				CustomerComment= request.CustomerComment,
				CustomerName = request.CustomerName,
				CustomerImage = request.CustomerImage,
				RaytingValue = request.RaytingValue,
				ReviewDate=DateTime.Parse(DateTime.Now.ToShortDateString()),
			});
		}
	}
}
