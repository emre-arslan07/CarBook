using CarBook.Application.Features.Queries.SocialMediaQueries;
using CarBook.Application.Features.Results.ServiceResults;
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
    public class GetSocialMediaByIdQueryHandler : IRequestHandler<GetSocialMediaByIdQuery, GetSocialMediaByIdQueryResult>
    {
        private readonly IRepository<SocialMedia> _repository;

        public GetSocialMediaByIdQueryHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task<GetSocialMediaByIdQueryResult> Handle(GetSocialMediaByIdQuery request, CancellationToken cancellationToken)
        {
            var query = await _repository.Get(request.Id);
            if (query != null)
            {
                return new GetSocialMediaByIdQueryResult
                {
                    Icon = query.Icon,
                    Id=query.ID,
                    Name = query.Name,
                    Url=query.Url
                };

            }
            else
            {
                return null;
            }
        }
    }
}
