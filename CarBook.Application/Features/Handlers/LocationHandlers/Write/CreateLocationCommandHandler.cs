using CarBook.Application.Features.Commands.LocationCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Handlers.LocationHandlers.Write
{
    public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand, bool>
    {
        private readonly IRepository<Location> _repository;

        public CreateLocationCommandHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {
            return await _repository.AddAsync(new Location
            {
                Name = request.Name
            });
        }
    }
}
