using FluentValidation;
using LibraLoan.Application.Commands.CreateBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraLoan.Application.Validators
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator() {
            RuleFor(p => p.Title)
                .MinimumLength(100).WithMessage("Title must have no more than 100 characters")
                .NotEmpty().WithMessage("Title is required");
            
            RuleFor(p => p.Author)
                .MinimumLength(100).WithMessage("Title must have no more than 100 characters")
                .NotEmpty().WithMessage("Author is required");

            RuleFor(p => p.ISBN)
                    .NotEmpty().WithMessage("ISBN is required")
                    .Matches(@"\b\d{13}\b").WithMessage("ISBN must be a 13-digit number");

            RuleFor(p => p.PublishedYear)
                .NotEmpty().WithMessage("Published year is required")
                .Matches(@"^\d{4}$").WithMessage("Published year must be a 4-digit year");

        }
    }
}
