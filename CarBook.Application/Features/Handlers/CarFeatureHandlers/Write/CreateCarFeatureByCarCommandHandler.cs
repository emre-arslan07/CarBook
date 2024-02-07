using CarBook.Application.Features.Commands.CarFeatureCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Handlers.CarFeatureHandlers.Write
{
    public class CreateCarFeatureByCarCommandHandler : IRequestHandler<CreateCarFeatureByCarCommand, bool>
    {
        private readonly IRepository<CarFeature> _repository;

        public CreateCarFeatureByCarCommandHandler(IRepository<CarFeature> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(CreateCarFeatureByCarCommand request, CancellationToken cancellationToken)
        {
            return await _repository.AddAsync(new CarFeature
            {
                CarId = request.CarId,
                FeatureId = request.FeatureId,
                Available = false
            });
        }
    }
}
