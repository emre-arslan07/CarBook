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
    public class GetContactByIdQueryHandler : IRequestHandler<GetContactByIdQuery, GetContactByIdQueryResult>
    {
        private readonly IRepository<Contact> _repository;

        public GetContactByIdQueryHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
        {
            var query = await _repository.Get(request.Id);
            return new GetContactByIdQueryResult
            {
                Id = query.ID,
                Email = query.Email,
                Message = query.Message,
                Name = query.Name,
                SendDate = query.SendDate,
                Subject = query.Subject
            };
        }
    }
}
