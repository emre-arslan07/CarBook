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
    public class GetCarCountByFuelGasolineOrDieselQueryHandler : IRequestHandler<GetCarCountByFuelGasolineOrDieselQuery, GetCarCountByFuelGasolineOrDieselQueryResult>
    {
        private readonly IStatisticRepository _statisticRepository;

        public GetCarCountByFuelGasolineOrDieselQueryHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetCarCountByFuelGasolineOrDieselQueryResult> Handle(GetCarCountByFuelGasolineOrDieselQuery request, CancellationToken cancellationToken)
        {
            var value = _statisticRepository.GetCarCountByFuelGasolineOrDiesel();
            return new GetCarCountByFuelGasolineOrDieselQueryResult { CarCountByFuelGasolineOrDiesel = value };
        }
    }
}
