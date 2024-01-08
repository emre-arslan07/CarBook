using CarBook.Application.Features.Commands.ContactCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Handlers.ContactHandlers.Write
{
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, bool>
    {
        private readonly IRepository<Contact> _repository;

        public CreateContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            return await _repository.AddAsync(new Contact
            {
                Email = request.Email,
                Message = request.Message,
                Name = request.Name,
                SendDate = request.SendDate,
                Subject = request.Subject
            });
        }
    }
}
