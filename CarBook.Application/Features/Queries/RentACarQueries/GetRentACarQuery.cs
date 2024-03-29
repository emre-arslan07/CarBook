﻿using CarBook.Application.Features.Results.RentACarResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.RentACarQueries
{
	public class GetRentACarQuery:IRequest<List<GetRentACarQueryResult>>
	{
		public GetRentACarQuery(int locationId, bool available)
		{
			LocationId = locationId;
			Available = available;
		}

		public int LocationId { get; set; }
        public bool Available { get; set; }
    }
}
