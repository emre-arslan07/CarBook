using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.CarDescriptionInterfaces
{
	public interface ICarDescriptonRepository
	{
		Task<CarDescription> GetCarDescriptonByCarIdAsync(int id);
	}
}
