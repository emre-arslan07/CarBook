using CarBook.Application.Features.Commands.CommentCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Handlers.CommentHandlers.Write
{
    public class RemoveCommentCommandHandler : IRequestHandler<RemoveCommentCommand, bool>
    {
        private readonly IRepository<Comment> _repository;

        public RemoveCommentCommandHandler(IRepository<Comment> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(RemoveCommentCommand request, CancellationToken cancellationToken)
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
