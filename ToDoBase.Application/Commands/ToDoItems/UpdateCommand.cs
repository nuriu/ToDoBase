using FluentValidation;
using MediatR;
using System;
using ToDoBase.Core.Entities;

namespace ToDoBase.Application.Commands.ToDoItems
{
    public class UpdateCommand : IRequest<ToDoItem>
    {
        public Guid ItemId { get; set; }
        public bool IsDone { get; set; }
        public string Username { get; set; }
    }

    public class UpdateCommandValidator : AbstractValidator<UpdateCommand>
    {
        public UpdateCommandValidator()
        {
            RuleFor(c => c.ItemId).NotEmpty();
            RuleFor(c => c.IsDone).NotEmpty();
        }
    }
}
