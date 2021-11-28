using FluentValidation;
using MediatR;
using ToDoBase.Core.Entities;
using ToDoBase.Core.Extensions;

namespace ToDoBase.Application.Commands.Users
{
    public class CreateCommand : IRequest<User>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class CreateCommandValidator : AbstractValidator<CreateCommand>
    {
        public CreateCommandValidator()
        {
            RuleFor(c => c.Username)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .Must(ShouldNotContainDigits).WithMessage("Username souldn't contain numbers.")
                .MaximumLength(25);

            RuleFor(c => c.Password)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .Must(ShouldContainDigits)
                .WithMessage("Password should contain numbers.")
                .MinimumLength(8);
        }

        private bool ShouldNotContainDigits(string s) => s.ShouldNotContainDigits();
        private bool ShouldContainDigits(string s) => s.ShouldContainDigits();
    }
}
