using CarBook.Application.Features.Queries.RentACarQueries;
using CarBook.Application.Features.Results.RentACarResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.RentACarInterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Handlers.RentACarHandlers.Read
{
	public class GetRentACarQueryHandler : IRequestHandler<GetRentACarQuery, List<GetRentACarQueryResult>>
	{
		private readonly IRentACarRepository _repository;

		public GetRentACarQueryHandler(IRentACarRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<GetRentACarQueryResult>> Handle(GetRentACarQuery request, CancellationToken cancellationToken)
		{
			
			if (request.Available==true)
			{
				var values = await _repository.GetByFilterAsync(x => x.LocationId == request.LocationId && x.Available == true);
				return values.Select(x => new GetRentACarQueryResult
				{
					CarId = x.CarId,
					Brand=x.Car.Brand.Name,
					Model=x.Car.Model,
					CoverImageUrl=x.Car.CoverImageUrl
				}).ToList();
			}
			else
			{
				var values = await _repository.GetByFilterAsync(x => x.LocationId == request.LocationId && x.Available == false);
				return values.Select(x => new GetRentACarQueryResult
				{
					CarId = x.CarId,
					Brand = x.Car.Brand.Name,
					Model = x.Car.Model,
					CoverImageUrl = x.Car.CoverImageUrl
				}).ToList();
			}
		}
	}
}
