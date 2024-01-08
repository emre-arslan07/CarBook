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
    public class CreateBannerCommandHandler : IRequestHandler<CreateBannerCommand, bool>
    {
        private readonly IRepository<Banner> _repository;

        public CreateBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(CreateBannerCommand request, CancellationToken cancellationToken)
        {
            return await _repository.AddAsync(new Banner
            {
                Title = request.Title,
                Description = request.Description,
                VideoDescription = request.VideoDescription,
                VideoUrl = request.VideoUrl
            });
        }
    }
}
