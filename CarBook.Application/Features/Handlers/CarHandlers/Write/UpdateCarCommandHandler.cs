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
    public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, bool>
    {
        private readonly IRepository<Car> _repository;

        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
        {
            return await _repository.Update(new Car
            {
                Fuel = request.Fuel,
                Transmission = request.Transmission,
                BigImageUrl = request.BigImageUrl,
                BrandId = request.BrandId,
                CoverImageUrl = request.CoverImageUrl,
                Km = request.Km,
                Luggace = request.Luggace,
                Model = request.Model,
                Seat = request.Seat,
                ID = request.Id,
            });
        }
    }
}
