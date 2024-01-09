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
    public class RemoveContactCommandHandler : IRequestHandler<RemoveContactCommand, bool>
    {
        private readonly IRepository<Contact> _repository;

        public RemoveContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(RemoveContactCommand request, CancellationToken cancellationToken)
        {
            var query = await _repository.Get(request.Id);
            if (query == null)
            {
                return false;
            }
            else
            {
                if (await _repository.Remove(query) == true)
                {
                    return true;
                }
                else { return false; }
            }
        }
    }
}
