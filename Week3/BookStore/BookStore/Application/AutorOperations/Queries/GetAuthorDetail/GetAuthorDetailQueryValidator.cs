using BookStore.Application.AutorOperations.Queries.GetAuthorDetail;
using FluentValidation;

namespace BookStore.Application.AutorOperations.Queries.GetAutorDetail
{
    public class GetAuthorDetailQueryValidator : AbstractValidator<GetAuthorDetailQuery>
    {
        public GetAuthorDetailQueryValidator() 
        {
            RuleFor(query => query.AuthorId).GreaterThan(0);
        }
    }
}
