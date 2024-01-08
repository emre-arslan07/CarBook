using CarBook.Application.Features.Queries.ContactQueries;
using CarBook.Application.Features.Results.ContactResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Handlers.ContactHandlers.Read
{
    public class GetContactQueryHandler : IRequestHandler<GetContactQuery, List<GetContactQueryResult>>
    {
        private readonly IRepository<Contact> _repository;

        public GetContactQueryHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetContactQueryResult>> Handle(GetContactQuery request, CancellationToken cancellationToken)
        {
            var query = await _repository.GetList();
            return  query.Select(x=>new GetContactQueryResult
            {
                Id=x.ID,
                Email=x.Email,
                Message=x.Message,
                Name=x.Name,
                SendDate=x.SendDate,
                Subject=x.Subject
            }).ToList();
        }
    }
}
