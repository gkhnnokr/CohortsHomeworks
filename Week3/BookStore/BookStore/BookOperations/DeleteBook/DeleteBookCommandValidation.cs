using FluentValidation;

namespace BookStore.BookOperations.DeleteBook;

public class DeleteBookCommandValidation : AbstractValidator<DeleteBookCommand>
{
    public DeleteBookCommandValidation() 
    {
        RuleFor(command => command.BookId).GreaterThan(0);
    }
}
