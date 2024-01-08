using CarBook.Application.Features.Commands.BrandCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Handlers.BrandHandlers.Write
{
    public class DeleteBrandCommandHandler : IRequestHandler<RemoveBrandCommand, bool>
    {
        private readonly IRepository<Brand> _repository;

        public DeleteBrandCommandHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(RemoveBrandCommand request, CancellationToken cancellationToken)
        {
            var query = await _repository.Get(request.Id);
            return await _repository.Remove(query);
        }
    }
}
