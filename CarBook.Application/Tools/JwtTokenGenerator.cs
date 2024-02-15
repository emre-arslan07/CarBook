using CarBook.Application.DTOs;
using CarBook.Application.Features.Results.AppUserResults;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Tools
{
	public class JwtTokenGenerator
	{
		public static TokenResponseDTO GenerateToken(GetCheckAppUserQueryResult result)
		{
			var claims = new List<Claim>();
			if (!string.IsNullOrWhiteSpace(result.Role))
			{
				claims.Add(new Claim(ClaimTypes.Role, result.Role));
			}	

			claims.Add(new Claim(ClaimTypes.NameIdentifier, result.Id.ToString()));

			if (!string.IsNullOrWhiteSpace(result.Username))
			{
				claims.Add(new Claim("Username", result.Username));
			}

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key));
			var signInCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
			var expiredate = DateTime.UtcNow.AddDays(JwtTokenDefaults.Expire);

			JwtSecurityToken token = new JwtSecurityToken(issuer: JwtTokenDefaults.ValidIssuer, audience: JwtTokenDefaults.ValidAudience, claims: claims, notBefore: DateTime.UtcNow, expires: expiredate, signingCredentials: signInCredentials);

			JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
			return new TokenResponseDTO(handler.WriteToken(token),expiredate);
			}
		}
	}
