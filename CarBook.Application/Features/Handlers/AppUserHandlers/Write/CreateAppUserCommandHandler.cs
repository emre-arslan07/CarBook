using CarBook.Application.Enums;
using CarBook.Application.Features.Commands.AppUserCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Handlers.AppUserHandlers.Write
{
	public class CreateAppUserCommandHandler : IRequestHandler<CreateAppUserCommand, bool>
	{
		private readonly IRepository<AppUser> _repository;

		public CreateAppUserCommandHandler(IRepository<AppUser> repository)
		{
			_repository = repository;
		}

		public async Task<bool> Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
		{
			return await _repository.AddAsync(new AppUser
			{
				Username = request.Username,
				Password = request.Password,
				Email = request.Email,
				AppRoleId=(int)RolesType.Member,
				Name = request.Name,
				Surname= request.Surname,
			});	
		}
	}
}
