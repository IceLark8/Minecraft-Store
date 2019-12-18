using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using BLL.Mapper;
using BLL.Services.Impl;
using BLL.Services.Interfaces;
using DB;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace BLL
{
    public static class ConfigureBLLExtension
    {        
        public static void ConfigureBLL(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureAutoMapper();
            services.ConfigureServices();
            
            services.ConfigureDb(configuration);
        }

        private static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<ICartItemService, CartItemService>();
            services.AddScoped<IFeedbackService, FeedbackService>();
            services.AddScoped<ICommentService, CommentService>();
        }

        private static void ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddSingleton(new MapperConfiguration(c =>
            {
                c.AddProfile(new DomainProfile());
            }).CreateMapper());
        }
        
    }
}
