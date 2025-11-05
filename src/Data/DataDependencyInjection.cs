using Data.Interfaces;
using Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public static class DataIndependencyInjection
    {
        public static IServiceCollection AddData(this IServiceCollection services)
            => services
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped<IFollowRepository, FollowRepository>()
                .AddScoped<ILikeRepository, LikeRepository>()
                .AddScoped<IPostRepository, PostRepository>()
                .AddScoped<IRepostRepository, RepostRepository>()
                .AddScoped<IUserRepository, UserRepository>();
    }
}
