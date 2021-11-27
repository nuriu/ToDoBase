using MediatR;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ToDoBase.Core;

namespace ToDoBase.Application.Queries.Users
{
    public class AuthQueryHandler : IRequestHandler<AuthQuery, string>
    {
        public AuthQueryHandler()
        {

        }

        public async Task<string> Handle(AuthQuery request, CancellationToken cancellationToken)
        {
            // TODO: auth user with user service and handle user not found exception

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, "user")
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Constants.JWTSecret)), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
