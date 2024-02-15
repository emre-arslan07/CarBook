﻿using CarBook.Application.Features.Results.AppUserResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.AppUserQueries
{
	public class GetCheckAppUserQuery:IRequest<GetCheckAppUserQueryResult>
	{
		public GetCheckAppUserQuery(string username, string password)
		{
			Username = username;
			Password = password;
		}

		public string Username { get; set; }
        public string Password { get; set; }
    }
}
