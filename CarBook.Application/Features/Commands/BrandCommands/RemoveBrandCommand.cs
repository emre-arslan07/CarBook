using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.BrandCommands
{
    public class RemoveBrandCommand:IRequest<bool>
    {
        public RemoveBrandCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
