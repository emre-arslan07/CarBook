using CarBook.Application.Features.Queries.SocialMediaQueries;
using CarBook.Application.Features.Results.SocialMediaResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Handlers.SocialMediaHandlers.Read
{
    public class GetSocialMediaQueryHandler : IRequestHandler<GetSocialMediaQuery, List<GetSocialMediaQueryResult>>
    {
        private readonly IRepository<SocialMedia> _repository;

        public GetSocialMediaQueryHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetSocialMediaQueryResult>> Handle(GetSocialMediaQuery request, CancellationToken cancellationToken)
        {
            var query = await _repository.GetList();
            return query.Select(x =>new GetSocialMediaQueryResult{
                Id=x.ID,
                Icon=x.Icon,
                Name=x.Name,
                Url=x.Url
            }).ToList();
        }
    }
}
