using MediatR;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ToDoBase.Core;
using ToDoBase.Persistence.Services;

namespace ToDoBase.Application.Queries.Users
{
    public class AuthQueryHandler : IRequestHandler<AuthQuery, string>
    {
        private readonly IUserService _userService;

        public AuthQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<string> Handle(AuthQuery request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetAndAuthenticateUser(request.Username, request.Password);
            if (user == null)
            {
                // TODO: handle user not found exception
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Username)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Constants.JWTSecret)), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
