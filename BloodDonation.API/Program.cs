using BloodDonation.Application.Commands.CreateDonor;
using BloodDonation.Core.Repositories;
using BloodDonation.Infrastructure.Persistence.Context;
using BloodDonation.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// context
builder.Services.AddDbContext<BloodDonationDbContext>(options => options.UseInMemoryDatabase("BloodDonationDb"));

// mediatR
//builder.Services.AddMediatR(typeof(CreateDonorCommand));
var myHandlers = AppDomain.CurrentDomain.Load("BloodDonation.Application");
builder.Services.AddMediatR(m => m.RegisterServicesFromAssemblies(myHandlers));

// interfaces
builder.Services.AddScoped<IDonorRepository, DonorRepository>();



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
