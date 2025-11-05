using FluentValidation;
using Services.DTOs.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validators
{
    public class CreateQuoteRequestValidator : AbstractValidator<CreateQuoteRequest>
    {
        public CreateQuoteRequestValidator()
        {
            RuleFor(x => x.Content)
                .MaximumLength(280).WithMessage("Quote comment cannot exceed 280 characters.");

            RuleFor(x => x.QuotedPostId)
                .NotEmpty().WithMessage("Quoted post ID is required.");
        }
    }
}
