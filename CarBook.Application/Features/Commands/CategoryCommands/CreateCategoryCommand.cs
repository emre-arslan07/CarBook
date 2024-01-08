using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.CategoryCommands
{
    public class CreateCategoryCommand:IRequest<bool>
    {
        public string Name { get; set; }
    }
}
