using FluentValidation;
using Services.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validators
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username is required.")
                .MinimumLength(3).WithMessage("Username must be at least 3 characters long.")
                .MaximumLength(30).WithMessage("Username cannot exceed 30 characters.")
                .Matches("^[a-zA-Z0-9_]+$").WithMessage("Username can only contain letters, numbers, and underscores.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Email must be a valid email address.");

            RuleFor(x => x.PasswordHash)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.")
                .MaximumLength(100).WithMessage("Password cannot exceed 100 characters.");

            RuleFor(x => x.DisplayName)
                .NotEmpty().WithMessage("Display name is required.")
                .MaximumLength(50).WithMessage("Display name cannot exceed 50 characters.");

            RuleFor(x => x.Bio)
                .MaximumLength(160).WithMessage("Bio cannot exceed 160 characters.");

            RuleFor(x => x.ProfileImageUrl)
                .Must(url => string.IsNullOrEmpty(url) || Uri.IsWellFormedUriString(url, UriKind.Absolute))
                .WithMessage("Profile image URL must be a valid absolute URL.");
        }
    }

}
