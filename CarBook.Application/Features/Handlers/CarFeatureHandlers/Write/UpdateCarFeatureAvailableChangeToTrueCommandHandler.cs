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
    public class UpdateCarFeatureAvailableChangeToTrueCommandHandler :IRequestHandler<UpdateCarFeatureAvailableChangeToTrueCommand, bool>
    {
        private readonly IRepository<CarFeature> _repository;

        public UpdateCarFeatureAvailableChangeToTrueCommandHandler(IRepository<CarFeature> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateCarFeatureAvailableChangeToTrueCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.Get(request.Id);
            if (values == null)
            {
                return false;
            }
            else
            {
                values.Available = true;
                return await _repository.Update(values);

            }
        }
    }
}
