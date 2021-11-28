using FluentValidation;
using MediatR;
using System.Collections.Generic;
using ToDoBase.Core.Entities;

namespace ToDoBase.Application.Queries.ToDoItems
{
    public class ListQuery : IRequest<List<ToDoItem>>
    {
        public string Username { get; set; }
        public int Page { get; set; }
        public int ItemsPerPage { get; set; }
    }

    public class ListQueryValidator : AbstractValidator<ListQuery>
    {
        public ListQueryValidator()
        {
            RuleFor(q => q.Page).NotEmpty();
            RuleFor(q => q.ItemsPerPage).NotEmpty();
        }
    }
}
