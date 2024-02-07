using CarBook.Application.Interfaces.CarDescriptionInterfaces;
using CarBook.Domain.Entities;
using CarBook.Peristence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Peristence.Repositories.CarDescriptionRepositories
{
	public class CarDescriptionRepository : ICarDescriptonRepository
	{
		private readonly CarBookDbContext _context;

		public CarDescriptionRepository(CarBookDbContext context)
		{
			_context = context;
		}

		public async Task<CarDescription> GetCarDescriptonByCarIdAsync(int id)
		{
			return await _context.CarDescriptions.Where(x=>x.CarId == id).FirstOrDefaultAsync();
		}
	}
}
