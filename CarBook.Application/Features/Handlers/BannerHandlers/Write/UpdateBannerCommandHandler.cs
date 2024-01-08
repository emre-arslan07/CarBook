using CarBook.Application.Features.Commands.BannerCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Handlers.BannerHandlers.Write
{
    public class UpdateBannerCommandHandler : IRequestHandler<UpdateBannerCommand, bool>
    {
        private readonly IRepository<Banner> _repository;

        public UpdateBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateBannerCommand request, CancellationToken cancellationToken)
        {
            return await _repository.Update(new Banner
            {
                ID = request.Id,
                Description = request.Description,
                Title = request.Title,
                VideoDescription = request.VideoDescription,
                VideoUrl = request.VideoUrl
            });

        }
    }
}
