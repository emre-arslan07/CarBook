using CarBook.Application.Features.Commands.ServiceCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Handlers.ServiceHandlers.Write
{
    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand, bool>
    {
        private readonly IRepository<Service> _repository;

        public UpdateServiceCommandHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            return await _repository.Update(new Service
            {
                ID = request.Id,
                Description = request.Description,
                IconUrl = request.IconUrl,
                Title = request.Title
            });
        }
    }
}
