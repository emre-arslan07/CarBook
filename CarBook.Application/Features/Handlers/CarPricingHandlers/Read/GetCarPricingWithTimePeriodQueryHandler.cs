using CarBook.Application.Features.Queries.CarPricingQueries;
using CarBook.Application.Features.Results.CarPricingResults;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Handlers.CarPricingHandlers.Read
{
    public class GetCarPricingWithTimePeriodQueryHandler : IRequestHandler<GetCarPricingWithTimePeriodQuery, List<GetCarPricingWithTimePeriodQueryResult>>
    {
        private readonly ICarPricingRepository _carPricingRepository;

        public GetCarPricingWithTimePeriodQueryHandler(ICarPricingRepository carPricingRepository)
        {
            _carPricingRepository = carPricingRepository;
        }

        public async Task<List<GetCarPricingWithTimePeriodQueryResult>> Handle(GetCarPricingWithTimePeriodQuery request, CancellationToken cancellationToken)
        {
            var query = _carPricingRepository.GetCarPricingWithTimePeriod();
            return query.Select(x=> new GetCarPricingWithTimePeriodQueryResult
            {
                CoverImageUrl = x.CoverImageUrl,
                BrandModel=x.Brand+" "+x.Model,
                DailyAmount = x.Amounts[0],
                WeeklyAmount= x.Amounts[1],
                MonthlyAmount= x.Amounts[2]
            }).ToList();
        }
    }
}
