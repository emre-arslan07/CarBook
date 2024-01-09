using CarBook.Application.Features.Commands.CategoryCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Handlers.CategoryHandlers.Write
{
    public class RemoveCategoryCommandHandler : IRequestHandler<RemoveCategoryCommand, bool>
    {
        private readonly IRepository<Category> _repository;

        public RemoveCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
        {
            var query = await _repository.Get(request.Id);
            if (query == null)
            {
                return false;
            }
            else
            {
                if (await _repository.Remove(query) == true)
                {
                    return true;
                }
                else { return false; }
            }
        }
    }
}
