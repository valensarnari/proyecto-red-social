using FluentValidation;
using Services.DTOs.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validators
{
    public class CreatePostRequestValidator : AbstractValidator<CreatePostRequest>
    {
        public CreatePostRequestValidator()
        {
            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Post content is required.")
                .MaximumLength(280).WithMessage("Post content cannot exceed 280 characters.")
                .Must(content => !string.IsNullOrWhiteSpace(content))
                .WithMessage("Post content cannot contain only whitespace characters.");
        }
    }
}
