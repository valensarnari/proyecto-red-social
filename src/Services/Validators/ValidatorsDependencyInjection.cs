using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Services.DTOs.Posts;
using Services.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validators
{
    public static class ValidatorsDependencyInjection
    {
        public static IServiceCollection AddValidators(this IServiceCollection services)
            => services
                .AddScoped<IValidator<CreatePostRequest>, CreatePostRequestValidator>()
                .AddScoped<IValidator<CreateReplyRequest>, CreateReplyRequestValidator>()
                .AddScoped<IValidator<CreateQuoteRequest>, CreateQuoteRequestValidator>()
                .AddScoped<IValidator<LoginRequest>, LoginRequestValidator>()
                .AddScoped<IValidator<RegisterRequest>, RegisterRequestValidator>();
    }
}
