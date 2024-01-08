using CarBook.Application.Features.Queries.AboutQueries;
using CarBook.Application.Features.Results.AboutResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Handlers.AboutHandlers.Read
{
    partial class GetAboutByIdQueryHandler : IRequestHandler<GetAboutByIdQuery, GetAboutByIdQueryResult>
    {
        private readonly IRepository<About> _repository;

        public GetAboutByIdQueryHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task<GetAboutByIdQueryResult> Handle(GetAboutByIdQuery request, CancellationToken cancellationToken)
        {
            var query = await _repository.Get(request.Id);
            return new GetAboutByIdQueryResult
            {
                Id = query.ID,
                Description = query.Description,
                ImageUrl = query.ImageUrl,
                Title = query.Title
            };
        }
    }
}
