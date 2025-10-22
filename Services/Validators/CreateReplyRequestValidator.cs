using FluentValidation;
using Services.DTOs.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validators
{
    public class CreateReplyRequestValidator : AbstractValidator<CreateReplyRequest>
    {
        public CreateReplyRequestValidator()
        {
            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Reply content is required.")
                .MaximumLength(280).WithMessage("Reply content cannot exceed 280 characters.")
                .Must(content => !string.IsNullOrWhiteSpace(content))
                .WithMessage("Reply content cannot contain only whitespace characters.");

            RuleFor(x => x.ParentPostId)
                .NotEmpty().WithMessage("Parent post ID is required.");
        }
    }
}
