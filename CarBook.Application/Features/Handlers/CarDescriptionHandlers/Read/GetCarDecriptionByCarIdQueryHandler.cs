using CarBook.Application.Features.Queries.CarDescriptionQueries;
using CarBook.Application.Features.Results.CarDescriptionResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CarDescriptionInterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Handlers.CarDescriptionHandlers.Read
{
	public class GetCarDecriptionByCarIdQueryHandler : IRequestHandler<GetCarDescriptionByCarIdQuery, GetCarDecriptionByCarIdQueryResult>
	{
		private readonly ICarDescriptonRepository _repository;

		public GetCarDecriptionByCarIdQueryHandler(ICarDescriptonRepository repository)
		{
			_repository = repository;
		}

		public async Task<GetCarDecriptionByCarIdQueryResult> Handle(GetCarDescriptionByCarIdQuery request, CancellationToken cancellationToken)
		{
			var query = await _repository.GetCarDescriptonByCarIdAsync(request.Id);
			if (query != null)
			{
			return new GetCarDecriptionByCarIdQueryResult
			{
				CarId = query.CarId,
				Id = query.ID,
				Details = query.Details
			};
			}
			else
			{
				return null;
			}
		}
	}
}
