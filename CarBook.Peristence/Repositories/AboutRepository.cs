using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using CarBook.Peristence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Peristence.Repositories
{
    public class AboutRepository : Repository<About>, IAboutRepository
    {
        public AboutRepository(CarBookDbContext context) : base(context)
        {
        }
    }
}
