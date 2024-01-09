using CarBook.Application.Features.Commands.SocialMediaCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Handlers.SocialMediaHandlers.Write
{
    public class CreateSocialMediaCommandHandler : IRequestHandler<CreateSocialMediaCommand, bool>
    {
        private readonly IRepository<SocialMedia> _repository;

        public CreateSocialMediaCommandHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(CreateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            return await _repository.AddAsync(new SocialMedia
            {
                Icon = request.Icon,
                Name = request.Name,
                Url = request.Url
            });
        }
    }
}
