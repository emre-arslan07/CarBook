using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.CategoryCommands
{
    public class RemoveCategoryCommand:IRequest<bool>
    {
        public RemoveCategoryCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
