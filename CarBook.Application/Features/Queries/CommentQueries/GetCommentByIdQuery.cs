﻿using CarBook.Application.Features.Results.CommentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.CommentQueries
{
    public class GetCommentByIdQuery:IRequest<GetCommentByIdQueryResult>
    {
        public GetCommentByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
