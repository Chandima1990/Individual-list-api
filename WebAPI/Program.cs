using FluentValidation.AspNetCore;
using InSharpAssessment.DataRepositories.Context;
using InSharpAssessment.DataRepositories.DataManagers.Abstractions;
using InSharpAssessment.DataRepositories.DataManagers.Implementations;
using InSharpAssessment.Services.ServiceManagers.Abstractions;
using InSharpAssessment.Services.ServiceManagers.Implementations;
using InSharpAssessment.WebAPI.Infrastructure.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services
    .AddControllers(options =>
    {
        options.Filters.Add<HttpResponseExceptionFilter>();
    })
    .AddFluentValidation(fv =>
    {
        fv.RegisterValidatorsFromAssemblyContaining<Program>();
        fv.ImplicitlyValidateChildProperties = true;
    })
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });

// Using in memory database
builder.Services.AddDbContext<ApplicationDBContext>(opt =>
        opt.UseInMemoryDatabase("InSharpInMemoryDatabase")
        .EnableSensitiveDataLogging()
    );

builder.Services.AddCors();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddTransient<IIndividualService, IndividualService>();
builder.Services.AddTransient<IIndividualData, IndividualData>();

// Configure swagger docs
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "InSharp In Memory Database Assessment API",
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

    // Can allow specific origins, methods, headers etc.
    // for the ease of development allowed all
    app.UseCors(options =>
    {
        options.WithOrigins("*");
        options.AllowAnyMethod();
        options.AllowAnyHeader();
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
