using CarBook.Application.Features.Queries.StatisticQueries;
using CarBook.Application.Features.Results.StatisticResults;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Application.Interfaces.StatisticInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Handlers.StatisticHandlers.Read
{
    public class GetCarCountQueryHandler : IRequestHandler<GetCarCountQuery, GetCarCountQueryResult>
    {
        private readonly IStatisticRepository _statisticRepository;

      

        public GetCarCountQueryHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetCarCountQueryResult> Handle(GetCarCountQuery request, CancellationToken cancellationToken)
        {
            var value = _statisticRepository.GetCarCount();
            return new GetCarCountQueryResult
            {
                CarCount = value
            };
        }
    }
}
