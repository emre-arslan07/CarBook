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
    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, bool>
    {
        private readonly IRepository<Car> _repository;

        public CreateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            return await _repository.AddAsync(new Car
            {
                BigImageUrl = request.BigImageUrl,
                Luggace = request.Luggace,
                Km = request.Km,
                Model = request.Model,
                BrandId = request.BrandId,
                Fuel = request.Fuel,
                Seat = request.Seat,
                Transmission = request.Transmission,
                CoverImageUrl = request.CoverImageUrl,
            });
        }
    }
}
