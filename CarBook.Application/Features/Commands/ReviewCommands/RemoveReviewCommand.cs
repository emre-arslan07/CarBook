using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CarBook.Application.Features.Commands.ReviewCommands
{
	public class RemoveReviewCommand : IRequest<bool>
	{
		public RemoveReviewCommand(int id)
		{
			Id = id;
		}

		public int Id { get; set; }
    }
}
