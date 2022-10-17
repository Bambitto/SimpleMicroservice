global using FastEndpoints;
using BookService.AsyncDataServices;
using BookService.Data;
using BookService.Repository;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDoc();
if(builder.Environment.IsProduction())
{
    builder.Services.AddDbContext<AppDbContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("BookConn"));
    });
}
else
{ 
    builder.Services.AddDbContext<AppDbContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    });
}
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddSingleton<IMessageBusClient, MessageBusClient>();

var app = builder.Build();

app.UseFastEndpoints(s =>
{
    s.Endpoints.RoutePrefix = "api";
});

if(app.Environment.IsProduction())
{ 
    PrepDb.prepPopulation(app);
}

app.UseOpenApi();
app.UseSwaggerUi3(s => s.ConfigureDefaults());
app.Run();
