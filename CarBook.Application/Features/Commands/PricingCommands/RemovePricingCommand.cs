using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.PricingCommands
{
    public class RemovePricingCommand:IRequest<bool>
    {
        public RemovePricingCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
