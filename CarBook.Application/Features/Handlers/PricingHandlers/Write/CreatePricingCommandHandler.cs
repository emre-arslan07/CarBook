using CarBook.Application.Features.Commands.PricingCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Handlers.PricingHandlers.Write
{
    public class CreatePricingCommandHandler : IRequestHandler<CreatePricingCommand, bool>
    {
        private readonly IRepository<Pricing> _repository;

        public CreatePricingCommandHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(CreatePricingCommand request, CancellationToken cancellationToken)
        {
            return await _repository.AddAsync(new Pricing
            {
                Name = request.Name
            });
        }
    }
}
