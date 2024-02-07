using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.CarFeatureCommands
{
    public class UpdateCarFeatureAvailableChangeToFalseCommand:IRequest<bool>
    {
        public UpdateCarFeatureAvailableChangeToFalseCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
