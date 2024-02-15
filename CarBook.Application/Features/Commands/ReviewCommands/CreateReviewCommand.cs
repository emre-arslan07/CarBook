﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.ReviewCommands
{
	public class CreateReviewCommand:IRequest<bool>
	{
		public string CustomerName { get; set; }
		public string CustomerImage { get; set; }
		public string CustomerComment { get; set; }
		public int RaytingValue { get; set; }
		public DateTime ReviewDate { get; set; }
		public int CarId { get; set; }
	}
}
