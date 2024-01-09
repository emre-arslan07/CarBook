using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.PricingCommands
{
    public class CreatePricingCommand:IRequest<bool>
    {        
        public string Name { get; set; }
    }
}
