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
    public class UpdateAboutCommandHandler : IRequestHandler<UpdateAboutCommand, bool>
    {
        private readonly IRepository<About> _repository;

        public UpdateAboutCommandHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateAboutCommand request, CancellationToken cancellationToken)
        {
            return await _repository.Update(new About
            {
                Description = request.Description,
                ID=request.Id,
                ImageUrl = request.ImageUrl,
                Title=request.Title
            });
        }
    }
}
