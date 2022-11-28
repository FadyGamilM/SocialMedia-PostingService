using PostingService.Presentation.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// 1)==> register the database context
builder.Services.RegisterServices(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.Run();

