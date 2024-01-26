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
    public class GetCarCountByKmSmallerThan1000QueryHandler : IRequestHandler<GetCarCountByKmSmallerThan1000Query, GetCarCountByKmSmallerThan1000QueryResult>
    {
        private readonly IStatisticRepository _statisticRepository;

        public GetCarCountByKmSmallerThan1000QueryHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetCarCountByKmSmallerThan1000QueryResult> Handle(GetCarCountByKmSmallerThan1000Query request, CancellationToken cancellationToken)
        {
            var value = _statisticRepository.GetCarCountByKmSmallerThen1000();
            return new GetCarCountByKmSmallerThan1000QueryResult { CarCountByKmSmallerThan1000 = value };
        }
    }
}
