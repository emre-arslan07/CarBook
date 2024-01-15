﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.TestimonialCommands
{
	public class RemoveTestimonialCommand:IRequest<bool>
	{
		public RemoveTestimonialCommand(int id)
		{
			Id = id;
		}

		public int Id { get; set; }
    }
}
