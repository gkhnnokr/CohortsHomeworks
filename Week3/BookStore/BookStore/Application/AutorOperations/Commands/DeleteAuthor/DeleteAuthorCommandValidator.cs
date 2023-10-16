using FluentValidation;

namespace BookStore.Application.AutorOperations.Commands.DeleteAutor
{
    public class DeleteAuthorCommandValidator : AbstractValidator<DeleteAuthorCommand>
    {
        public DeleteAuthorCommandValidator() 
        {
            RuleFor(command => command.AuthorId).NotEmpty().GreaterThan(0);
        }
    }
}
