using CarBook.Application.Features.Commands.TagCloudCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Handlers.TagCloudHandlers.Write
{
    public class UpdateTagCloudCommandHandler : IRequestHandler<UpdateTagCloudCommand, bool>
    {
        private readonly IRepository<TagCloud> _repository;

        public UpdateTagCloudCommandHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateTagCloudCommand request, CancellationToken cancellationToken)
        {
            return await _repository.Update(new TagCloud
            {
                BlogId = request.BlogId,
                ID = request.Id,
                Title = request.Name
            });
        }
    }
}
