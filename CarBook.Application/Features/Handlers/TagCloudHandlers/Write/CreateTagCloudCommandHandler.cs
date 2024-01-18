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
    public class CreateTagCloudCommandHandler : IRequestHandler<CreateTagCloudCommand, bool>
    {
        private readonly IRepository<TagCloud> _repository;

        public CreateTagCloudCommandHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(CreateTagCloudCommand request, CancellationToken cancellationToken)
        {
            return await _repository.AddAsync(new TagCloud
            {
                BlogId = request.BlogId,
                Title = request.Name
            });
        }
    }
}
