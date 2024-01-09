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
    public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommand, bool>
    {
        private readonly IRepository<SocialMedia> _repository;

        public UpdateSocialMediaCommandHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            return await _repository.Update(new SocialMedia
            {
                ID = request.Id,
                Name = request.Name,
                Icon = request.Icon,
                Url = request.Url
            });
        }
    }
}
