using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.FeatureCommands
{
    public class RemoveFeatureCommand:IRequest<bool>
    {
        public RemoveFeatureCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
