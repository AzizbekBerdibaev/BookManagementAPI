using BookManagementAPI.Dtos;
using FluentValidation;

namespace BookManagementAPI.Validators
{
    public class UpdateBookDtoValidator : AbstractValidator<UpdateBookDto>
    {
        public UpdateBookDtoValidator()
        {
            RuleFor(r => r.Title)
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(r => r.Author)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(r => r.ISBN)
                .NotEmpty()
                .Length(13);

            RuleFor(r => r.Price)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(r => r.PublishedYear)
                .NotEmpty()
                .InclusiveBetween(1900, DateTime.UtcNow.Year);
        }
    }
}
