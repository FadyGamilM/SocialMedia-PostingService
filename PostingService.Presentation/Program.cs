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

// ==> call the reflection method to scan the whole assembly and register all the defined endpoints
app.RegisterWebApplicationServices();

app.Run();

