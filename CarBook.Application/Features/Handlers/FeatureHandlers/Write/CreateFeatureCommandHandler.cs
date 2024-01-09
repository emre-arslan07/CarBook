using CarBook.Application.Features.Commands.FeatureCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Handlers.FeatureHandlers.Write
{
    public class CreateFeatureCommandHandler : IRequestHandler<CreateFeatureCommand, bool>
    {
        private readonly IRepository<Feature> _repository;

        public CreateFeatureCommandHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(CreateFeatureCommand request, CancellationToken cancellationToken)
        {
            return await _repository.AddAsync(new Feature
            {
                Name = request.Name
            });
        }
    }
}
