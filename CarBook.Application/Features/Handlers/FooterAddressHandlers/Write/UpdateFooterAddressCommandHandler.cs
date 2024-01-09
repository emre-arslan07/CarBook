using CarBook.Application.Features.Commands.FooterAddressCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Handlers.FooterAddressHandlers.Write
{
    public class UpdateFooterAddressCommandHandler : IRequestHandler<UpdateFooterAddressCommand, bool>
    {
        private readonly IRepository<FooterAddress> _repository;

        public UpdateFooterAddressCommandHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateFooterAddressCommand request, CancellationToken cancellationToken)
        {
            return await _repository.Update(new FooterAddress
            {
                ID = request.Id,
                Address = request.Address,
                Description = request.Description,
                Email = request.Email,
                Phone = request.Phone
            });
        }
    }
}
