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
    public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand, bool>
    {
        private readonly IRepository<Location> _repository;

        public UpdateLocationCommandHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
        {
            return await _repository.Update(new Location
            {
                ID = request.Id,
                Name = request.Name
            });
        }
    }
}
