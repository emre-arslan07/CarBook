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
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, bool>
    {
        private readonly IRepository<Comment> _repository;

        public UpdateCommentCommandHandler(IRepository<Comment> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            return await _repository.Update(new Comment
            {
                BlogId = request.BlogId,
                CreatedDate = request.CreatedDate,
                Description = request.Description,
                ID = request.Id,
                Name = request.Name
            });
        }
    }
}
