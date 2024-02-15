using CarBook.Application.Features.Queries.ReviewQueries;
using CarBook.Application.Features.Results.ReviewResults;
using CarBook.Application.Interfaces.ReviewInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Handlers.ReviewHandler.Read
{
	public class GetReviewByCarIdQueryHandler : IRequestHandler<GetReviewByCarIdQuery, List<GetReviewByCarIdQueryResult>>
	{
		private readonly IReviewRepository _reviewRepository;

		public GetReviewByCarIdQueryHandler(IReviewRepository reviewRepository)
		{
			_reviewRepository = reviewRepository;
		}

		public async Task<List<GetReviewByCarIdQueryResult>> Handle(GetReviewByCarIdQuery request, CancellationToken cancellationToken)
		{
			var query = await _reviewRepository.GetReviewsByCarId(request.Id);
			return query.Select(x => new GetReviewByCarIdQueryResult
			{
				CarId = x.CarId,
				Id = x.ID,
				CustomerComment = x.CustomerComment,
				CustomerImage = x.CustomerImage,
				CustomerName = x.CustomerName,
				RaytingValue = x.RaytingValue,
				ReviewDate = x.ReviewDate
			}).ToList();
		}
	}
}
