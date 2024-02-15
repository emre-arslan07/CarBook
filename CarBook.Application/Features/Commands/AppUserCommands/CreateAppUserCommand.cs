using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.AppUserCommands
{
	public class CreateAppUserCommand:IRequest<bool>
	{
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }
	}
}
