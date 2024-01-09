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
    public class RemovePricingCommandHandler : IRequestHandler<RemovePricingCommand, bool>
    {
        private readonly IRepository<Pricing> _repository;

        public RemovePricingCommandHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(RemovePricingCommand request, CancellationToken cancellationToken)
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
