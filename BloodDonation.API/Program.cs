using BloodDonation.Application.Commands.CreateDonor;
using BloodDonation.Core.Repositories;
using BloodDonation.Infrastructure.Persistence.Context;
using BloodDonation.Infrastructure.Persistence.Repositories;
using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BloodDonation.Application.Validators;
using BloodDonation.API.Filters;
using System.Reflection;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.Filters.Add(typeof(ValidationFilter)))
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateDonorCommandValidator>());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo 
    { 
        Title = "BloodDonation.API", 
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "Vitor Santos Alves",
            Url = new Uri("https://www.linkedin.com/in/vitor-santos-alves/")
        }
    
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    opt.IncludeXmlComments(xmlPath);
});

// context
var connectionString = builder.Configuration.GetConnectionString("BloodDonationDb");
builder.Services.AddDbContext<BloodDonationDbContext>(options => options.UseSqlServer(connectionString));

// mediatR
var myHandlers = AppDomain.CurrentDomain.Load("BloodDonation.Application");
builder.Services.AddMediatR(m => m.RegisterServicesFromAssemblies(myHandlers));

// interfaces
builder.Services.AddScoped<IDonorRepository, DonorRepository>();
builder.Services.AddScoped<IDonationRepository, DonationRepository>();
builder.Services.AddScoped<IStockRepository, StockRepository>();

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
