using Microsoft.Extensions.DependencyInjection;
using Services.UseCases.Follows;
using Services.UseCases.Likes;
using Services.UseCases.Posts;
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
                .AddUserUseCases()
                .AddPostUseCases()
                .AddLikeUseCases()
                .AddFollowUseCases();

        private static IServiceCollection AddRepostUseCases(this IServiceCollection services)
            => services.AddScoped<RepostUseCases>()
                .AddScoped<CreateRepost>()
                .AddScoped<DeleteRepost>()
                .AddScoped<GetRepostsByPost>();

        private static IServiceCollection AddUserUseCases(this IServiceCollection services)
            => services.AddScoped<UserUseCases>()
                .AddScoped<Login>()
                .AddScoped<Register>()
                .AddScoped<GetUser>();

        private static IServiceCollection AddPostUseCases(this IServiceCollection services)
            => services.AddScoped<PostUseCases>()
                .AddScoped<DeletePost>()
                .AddScoped<CreatePost>()
                .AddScoped<GetPost>()
                .AddScoped<GetUserTimeline>()
                .AddScoped<GetPostReplies>()
                .AddScoped<CreateReply>()
                .AddScoped<CreateQuote>();

        private static IServiceCollection AddLikeUseCases(this IServiceCollection services)
            => services.AddScoped<LikeUseCases>()
                .AddScoped<CreateLike>()
                .AddScoped<DeleteLike>()
                .AddScoped<GetLikesByPost>()
                .AddScoped<GetLikesByUser>();

        private static IServiceCollection AddFollowUseCases(this IServiceCollection services)
            => services.AddScoped<FollowUseCases>()
                .AddScoped<CreateFollow>()
                .AddScoped<DeleteFollow>()
                .AddScoped<GetFollowers>()
                .AddScoped<GetFollowing>();
    }
}
