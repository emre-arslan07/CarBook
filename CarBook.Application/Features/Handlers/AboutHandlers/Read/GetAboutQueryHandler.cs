using CarBook.Application.Features.Queries.AboutQueries;
using CarBook.Application.Features.Results.AboutResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Handlers.AboutHandlers.Read
{
    public class GetAboutQueryHandler : IRequestHandler<GetAboutQuery, List<GetAboutQueryResult>>
    {
        private readonly IRepository<About> _repository;

        public GetAboutQueryHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAboutQueryResult>> Handle(GetAboutQuery request, CancellationToken cancellationToken)
        {
            var query =await _repository.GetList();
            return query.Select(x => new GetAboutQueryResult
            {
                Id = x.ID,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                Title = x.Title
            }).ToList();
        }
    }
}
