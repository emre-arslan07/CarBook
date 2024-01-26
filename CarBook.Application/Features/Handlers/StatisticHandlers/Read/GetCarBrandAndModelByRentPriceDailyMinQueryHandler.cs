using CarBook.Application.Features.Queries.StatisticQueries;
using CarBook.Application.Features.Results.StatisticResults;
using CarBook.Application.Interfaces.StatisticInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Handlers.StatisticHandlers.Read
{
    public class GetCarBrandAndModelByRentPriceDailyMinQueryHandler : IRequestHandler<GetCarBrandAndModelByRentPriceDailyMinQuery, GetCarBrandAndModelByRentPriceDailyMinQueryResult>
    {
        private readonly IStatisticRepository _statisticRepository;

        public GetCarBrandAndModelByRentPriceDailyMinQueryHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetCarBrandAndModelByRentPriceDailyMinQueryResult> Handle(GetCarBrandAndModelByRentPriceDailyMinQuery request, CancellationToken cancellationToken)
        {
            var value = _statisticRepository.GetCarBrandAndModelByRentPriceDailyMin();
            return new GetCarBrandAndModelByRentPriceDailyMinQueryResult { CarBrandAndModelByRentPriceDailyMin = value };
        }
    }
}
