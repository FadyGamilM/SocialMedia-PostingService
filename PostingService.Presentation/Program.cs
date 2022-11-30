using MediatR;
using PostingService.Application.UseCases.Posts.Commands;
using PostingService.Application.UseCases.Posts.Queries;
using PostingService.Domain.Entities;
using PostingService.Presentation.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// 1)==> register the database context
builder.Services.RegisterServices(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

// routes endpoints 
app.MapGet("/api/posts/{id}",
    async (IMediator mediator, int id) =>
    {
        // create the query
        var query = new GetPostByIdQuery
        {
            Id = id,
        };

        // utilize the query handler to get the response
        var response = await mediator.Send(query);

        // return the appropriate response
        return Results.Ok(response);
    })
    .WithName("GetPostById");


app.MapPost("/api/posts", 
    async (IMediator mediator, Post post) => 
    {
        // create command instance
        var command = new CreatePostCommand { Content = post.Content };

        // utilize the command handler to get the response
        var response = await mediator.Send(command);

        // return the response
        return Results.CreatedAtRoute(
            "GetPostById", // the ma,e pf the route to transfer the user into 
            new { response.Id }, // the required parameters of the route to be mapped to "GetPostById"
            response // the body of the response
            );
    });

app.MapGet("/api/posts", 
    async (IMediator mediator) => 
    {
        var query = new GetPostsQuery();

        var response = await mediator.Send(query);

        return Results.Ok(response);
    });

app.MapPut("/api/posts/{id}", 
    async (IMediator mediator, Post post, int id) =>
    {
        var command = new UpdatePostCommand { Content = post.Content, Id = id };

        var response = await mediator.Send(command);

        return Results.Ok(response);
    });

app.MapDelete("/api/posts/{id}",
    async (IMediator mediator, int id) =>
    {
        var command = new DeletePostCommand { Id = id };

        await mediator.Send(command);

        return Results.NoContent();
    });



app.Run();

