using FluentValidation;
using MediatR;
using ToDoBase.Core.Entities;

namespace ToDoBase.Application.Commands.ToDoItems
{
    public class CreateCommand : IRequest<ToDoItem>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Username { get; set; }
    }

    public class CreateCommandValidator : AbstractValidator<CreateCommand>
    {
        public CreateCommandValidator()
        {
            RuleFor(c => c.Title)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .MaximumLength(25);

            RuleFor(c => c.Description).MaximumLength(1500);
        }
    }
}
