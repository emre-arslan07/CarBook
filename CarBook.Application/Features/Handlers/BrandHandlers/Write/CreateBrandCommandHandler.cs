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
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, bool>
    {
        private readonly IRepository<Brand> _repository;

        public CreateBrandCommandHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            return await _repository.AddAsync(new Brand
            {
                Name = request.Name,
            });
        }
    }
}
