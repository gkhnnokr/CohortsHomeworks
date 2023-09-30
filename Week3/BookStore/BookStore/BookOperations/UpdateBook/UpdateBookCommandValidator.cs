using FluentValidation;

namespace BookStore.BookOperations.UpdateBook;

public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
{
    public UpdateBookCommandValidator()
    {
        RuleFor(command => command.BookId).NotEmpty().GreaterThan(0);
        RuleFor(command => command.Model.GenreId).GreaterThan(0);
        RuleFor(command => command.Model.Title).MinimumLength(4).NotEmpty().NotNull();
    }
}
