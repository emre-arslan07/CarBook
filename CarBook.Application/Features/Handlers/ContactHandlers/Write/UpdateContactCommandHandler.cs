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
    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, bool>
    {
        private readonly IRepository<Contact> _repository;

        public UpdateContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            return await _repository.Update(new Contact
            {
                ID = request.Id,
                Email = request.Email,
                Message = request.Message,
                Name = request.Name,
                SendDate = request.SendDate,
                Subject = request.Subject
            });
        }
    }
}
