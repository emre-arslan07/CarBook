using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.CommentCommands
{
    public class RemoveCommentCommand:IRequest<bool>
    {
        public RemoveCommentCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
