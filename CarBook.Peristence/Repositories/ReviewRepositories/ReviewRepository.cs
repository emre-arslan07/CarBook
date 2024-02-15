using CarBook.Application.Interfaces.ReviewInterfaces;
using CarBook.Domain.Entities;
using CarBook.Peristence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Peristence.Repositories.ReviewRepositories
{
	public class ReviewRepository : IReviewRepository
	{
		private readonly CarBookDbContext _context;

		public ReviewRepository(CarBookDbContext context)
		{
			_context = context;
		}

		public async Task<List<Review>> GetReviewsByCarId(int id)
		{
			return await _context.Reviews.Where(x=>x.CarId == id).ToListAsync();
		}
	}
}
