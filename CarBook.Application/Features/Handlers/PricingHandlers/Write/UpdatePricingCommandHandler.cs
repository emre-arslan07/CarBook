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
    public class UpdatePricingCommandHandler : IRequestHandler<UpdatePricingCommand, bool>
    {
        private readonly IRepository<Pricing> _repository;

        public UpdatePricingCommandHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        public Task<bool> Handle(UpdatePricingCommand request, CancellationToken cancellationToken)
        {
            return _repository.Update(new Pricing
            {
                ID = request.Id,
                Name = request.Name
            });
        }
    }
}
