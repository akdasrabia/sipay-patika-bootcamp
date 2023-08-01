using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using odev2.API.Middlewares;
using odev2.Core.Repositories;
using odev2.Core.Services;
using odev2.Repository;
using odev2.Repository.Repositories;
using odev2.Service.Services;
using odev2.Service.Validations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<BlogValidator>());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));




builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase(databaseName: "BlogDb"));

var app = builder.Build();


// data generator initialize
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    DataGenerator.Initialize(services);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCustomMiddleware();

app.MapControllers();

app.Run();
