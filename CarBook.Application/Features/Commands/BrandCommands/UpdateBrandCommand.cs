﻿using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.BrandCommands
{
    public class UpdateBrandCommand:IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
