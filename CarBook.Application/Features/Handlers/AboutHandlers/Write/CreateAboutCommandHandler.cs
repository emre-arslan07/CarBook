using CarBook.Application.Features.Commands.AboutCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Handlers.AboutHandlers.Write
{
    public class CreateAboutCommandHandler : IRequestHandler<CreateAboutCommand, bool>
    {
        private readonly IRepository<About> _repository;

        public CreateAboutCommandHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(CreateAboutCommand request, CancellationToken cancellationToken)
        {
            return await _repository.AddAsync(new About
            {
                Description = request.Description,
                ImageUrl = request.ImageUrl,
                Title = request.Title
            });
        }
    }
}
