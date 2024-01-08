using CarBook.Application.Features.Queries.BannerQueries;
using CarBook.Application.Features.Results.BannerResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Handlers.BannerHandlers.Read
{
    public class GetBannerByIdQueryHandler : IRequestHandler<GetBannerByIdQuery, GetBannerByIdQueryResult>
    {
        private readonly IRepository<Banner> _repository;

        public GetBannerByIdQueryHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task<GetBannerByIdQueryResult> Handle(GetBannerByIdQuery request, CancellationToken cancellationToken)
        {
            var query = await _repository.Get(request.Id);
            return new GetBannerByIdQueryResult
            {
                Id=query.ID,
                Description = query.Description,
                Title = query.Title,
                VideoDescription = query.VideoDescription,
                VideoUrl = query.VideoUrl,
            };
        }
    }
}
