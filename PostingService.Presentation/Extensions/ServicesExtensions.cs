using Microsoft.EntityFrameworkCore;
using PostingService.Application.Abstractions;
using PostingService.DataAccess;
using PostingService.DataAccess.Repositories;
using MediatR;
using PostingService.Application.UseCases.Posts.Commands;

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

        // inject the command/query handlers to their commands/queries using mediator
        builder.Services.AddMediatR(typeof(CreatePostCommand));



        return services;

    }
}
