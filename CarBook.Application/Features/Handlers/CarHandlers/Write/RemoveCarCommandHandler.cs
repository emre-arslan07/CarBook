using CarBook.Application.Features.Commands.CarCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Handlers.CarHandlers.Write
{
    public class RemoveCarCommandHandler : IRequestHandler<RemoveCarCommand, bool>
    {
        private readonly IRepository<Car> _repository;

        public RemoveCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(RemoveCarCommand request, CancellationToken cancellationToken)
        {
            var query = await _repository.Get(request.Id);
            return await _repository.Remove(query);
        }
    }
}
