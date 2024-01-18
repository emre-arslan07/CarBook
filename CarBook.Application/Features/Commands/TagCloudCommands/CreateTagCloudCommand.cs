using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.TagCloudCommands
{
    public class CreateTagCloudCommand:IRequest<bool>
    {
        public string Name { get; set; }
        public int BlogId { get; set; }
    }
}
