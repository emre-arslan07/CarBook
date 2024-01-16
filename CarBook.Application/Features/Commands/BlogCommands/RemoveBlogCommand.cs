using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.BlogCommands
{
    public class RemoveBlogCommand:IRequest<bool>
    {
        public RemoveBlogCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
