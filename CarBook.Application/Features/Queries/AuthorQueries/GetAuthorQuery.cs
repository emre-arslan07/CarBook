﻿using CarBook.Application.Features.Results.AuthorResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.AuthorQueries
{
    public class GetAuthorQuery:IRequest<List<GetAuthorQueryResult>>
    {
    }
}
