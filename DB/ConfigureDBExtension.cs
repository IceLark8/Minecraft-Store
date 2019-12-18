using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DB.Repositories.Impl;
using DB.Repositories.InterFaces;
using DB.UnitOfWork;
using DB;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace DB
{
    public static class ConfigureDBExtension
    {
        public static void ConfigureDb(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.ConfigureRepositories();
            services.ConfigureDbContext(configuration);

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        private static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IFeedbackRepository, FeedbackRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICartItemRepository, CartItemRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
        }

        private static void ConfigureDbContext(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            void ConfigureConnection(DbContextOptionsBuilder options)
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("StudVoice.DAL"));
            }

            services.AddDbContext<StoreDbContext>(ConfigureConnection);
        }
    }
}
