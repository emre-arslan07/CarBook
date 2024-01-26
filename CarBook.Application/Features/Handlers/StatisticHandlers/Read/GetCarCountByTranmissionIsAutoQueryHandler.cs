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
    public class GetCarCountByTranmissionIsAutoQueryHandler : IRequestHandler<GetCarCountByTranmissionIsAutoQuery, GetCarCountByTranmissionIsAutoCountQueryResult>
    {
        private readonly IStatisticRepository _statisticRepository;

        public GetCarCountByTranmissionIsAutoQueryHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetCarCountByTranmissionIsAutoCountQueryResult> Handle(GetCarCountByTranmissionIsAutoQuery request, CancellationToken cancellationToken)
        {
            var value = _statisticRepository.GetCarCountByTranmissionIsAuto();
            return new GetCarCountByTranmissionIsAutoCountQueryResult { CarCountByTranmissionIsAutoCount = value };
        }
    }
}
