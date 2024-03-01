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

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.Filters.Add(typeof(ValidationFilter)))
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateDonorCommandValidator>());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
