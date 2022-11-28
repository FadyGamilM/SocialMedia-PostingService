using Microsoft.EntityFrameworkCore;
using PostingService.Application.Abstractions;
using PostingService.DataAccess;
using PostingService.DataAccess.Repositories;

namespace PostingService.Presentation.Extensions;

public static class ServicesExtensions
{
    public static IServiceCollection RegisterServices(this IServiceCollection services, WebApplicationBuilder builder)
    {
        // register db context
        builder.Services.AddDbContext<PostingServiceDbContext>(opts => 
            opts.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")
                )
        );

        // inject post repository service
        builder.Services.AddScoped<IPostRepository, PostRepository>();
        return services;
    }
}
