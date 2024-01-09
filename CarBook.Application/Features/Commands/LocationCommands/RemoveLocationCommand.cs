using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.LocationCommands
{
    public class RemoveLocationCommand:IRequest<bool>
    {
        public RemoveLocationCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
