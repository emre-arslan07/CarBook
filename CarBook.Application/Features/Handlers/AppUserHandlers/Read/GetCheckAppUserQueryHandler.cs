using CarBook.Application.Features.Queries.AppUserQueries;
using CarBook.Application.Features.Results.AppUserResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Handlers.AppUserHandlers.Read
{
	public class GetCheckAppUserQueryHandler : IRequestHandler<GetCheckAppUserQuery, GetCheckAppUserQueryResult>
	{
		private readonly IRepository<AppUser> _appUserRepository;
		private readonly IRepository<AppRole> _appRoleRepository;

		public GetCheckAppUserQueryHandler(IRepository<AppUser> appUserRepository, IRepository<AppRole> appRoleRepository)
		{
			_appUserRepository = appUserRepository;
			_appRoleRepository = appRoleRepository;
		}

		public async Task<GetCheckAppUserQueryResult> Handle(GetCheckAppUserQuery request, CancellationToken cancellationToken)
		{
			var user=await _appUserRepository.GetSingleAsync(x=>x.Username==request.Username && x.Password==request.Password);
            if (user==null)
            {
				return new GetCheckAppUserQueryResult
				{
					IsExist = false,
					
				};
			}
			else
			{
				return new GetCheckAppUserQueryResult
				{
					IsExist = true,
					Username = user.Username,
					Role = (await _appRoleRepository.GetSingleAsync(x => x.ID == user.AppRoleId))?.AppRoleName,
					Id=user.ID
				};
			}
        }
	}
}
