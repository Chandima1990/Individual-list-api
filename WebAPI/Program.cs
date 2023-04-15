using InSharpAssessment.DataRepositories.Context;
using InSharpAssessment.DataRepositories.DataManagers.Abstractions;
using InSharpAssessment.DataRepositories.DataManagers.Implementations;
using InSharpAssessment.Services.ServiceManagers.Abstractions;
using InSharpAssessment.Services.ServiceManagers.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Using in memory database
builder.Services.AddDbContext<ApplicationDBContext>(opt =>
    opt.UseInMemoryDatabase("InSharpInMemoryDatabase"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddTransient<IAddressService, AddressService>();
builder.Services.AddTransient<IIndividualService, IndividualService>();
builder.Services.AddTransient<IAddressData, AddressData>();
builder.Services.AddTransient<IIndividualData, IndividualData>();

// Configure swagger docs
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "InSharp In Memory Database Test API",
        Version = "v1",
        Description = "An API to perform individual's list operations"
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
