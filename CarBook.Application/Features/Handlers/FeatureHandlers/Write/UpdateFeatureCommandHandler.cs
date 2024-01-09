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
    public class UpdateFeatureCommandHandler : IRequestHandler<UpdateFeatureCommand, bool>
    {
        private readonly IRepository<Feature> _repository;

        public UpdateFeatureCommandHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateFeatureCommand request, CancellationToken cancellationToken)
        {
            return await _repository.Update(new Feature
            {
                ID = request.Id,
                Name = request.Name
            });
        }
    }
}
