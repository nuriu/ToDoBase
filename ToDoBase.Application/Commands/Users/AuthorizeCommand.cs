using FluentValidation;
using MediatR;

namespace ToDoBase.Application.Commands.Users
{
    public class AuthorizeCommand : IRequest<string>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class AuthorizeCommandValidator : AbstractValidator<AuthorizeCommand>
    {
        public AuthorizeCommandValidator()
        {
            RuleFor(q => q.Username).NotEmpty();
            RuleFor(q => q.Password).NotEmpty();
        }
    }
}
