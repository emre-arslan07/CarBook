using CarBook.Application.Features.Queries.RentACarQueries;
using CarBook.Application.Features.Results.RentACarResults;
using CarBook.Application.Interfaces;
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
		private readonly IRepository<RentACar> _repository;

		public GetRentACarQueryHandler(IRepository<RentACar> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetRentACarQueryResult>> Handle(GetRentACarQuery request, CancellationToken cancellationToken)
		{
			var values =await _repository.GetList(x => x.LocationId == request.LocationId && x.Available == true);
			return values.Select(x=>new GetRentACarQueryResult
			{
				CarId=x.CarId
			}).ToList();

		}
	}
}
