using CarBook.Application.Features.Commands.AuthorCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Handlers.AuthorHandlers.Write
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, bool>
    {
        private readonly IRepository<Author> _repository;

        public CreateAuthorCommandHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            return await _repository.AddAsync(new Author
            {
                Description = request.Description,
                ImageUrl = request.ImageUrl,
                Name = request.Name
            });
        }
    }
}
