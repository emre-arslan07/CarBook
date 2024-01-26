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
    partial class GetBlogCountQueryHandler : IRequestHandler<GetBlogCountQuery, GetBlogCountQueryResult>
    {
        private readonly IStatisticRepository _statisticRepository;

        public GetBlogCountQueryHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetBlogCountQueryResult> Handle(GetBlogCountQuery request, CancellationToken cancellationToken)
        {
            var value = _statisticRepository.GetBlogCount();
            return new GetBlogCountQueryResult
            {
                BlogCount = value
            };
        }
    }
}
