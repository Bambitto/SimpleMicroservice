global using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using ReviewService.AsyncDataServices;
using ReviewService.Data;
using ReviewService.EventProcessing;
using ReviewService.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints();
builder.Services.AddHostedService<MessageBusSubscriber>();
builder.Services.AddDbContext<AppDbContext>(options =>
    {
        options.UseInMemoryDatabase("InMem");
    });

builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddSingleton<IEventProcessor, EventProcessor>();
var app = builder.Build();


app.UseFastEndpoints(c =>
{
    c.Endpoints.RoutePrefix = "api";
});



app.Run();
