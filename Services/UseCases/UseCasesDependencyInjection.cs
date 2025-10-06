using Microsoft.Extensions.DependencyInjection;
using Services.UseCases.Reposts;
using Services.UseCases.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.UseCases
{
    public static class UseCasesDependencyInjection
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        => services
            .AddRepostUseCases()
            .AddUserUseCases();

        private static IServiceCollection AddRepostUseCases(this IServiceCollection services)
            => services.AddScoped<RepostUseCases>()
                .AddScoped<CreateRepost>()
                .AddScoped<DeleteRepost>();

        private static IServiceCollection AddUserUseCases(this IServiceCollection services)
            => services.AddScoped<UserUseCases>()
                .AddScoped<Login>()
                .AddScoped<Register>()
                .AddScoped<GetUser>();
    }
}
