using FluentValidation;
using MediatR;

namespace ToDoBase.Application.Queries.Users
{
    public class AuthQuery : IRequest<string>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class AuthQueryValidator : AbstractValidator<AuthQuery>
    {
        public AuthQueryValidator()
        {
            RuleFor(q => q.Username).NotEmpty();
            RuleFor(q => q.Password).NotEmpty();
        }
    }
}
