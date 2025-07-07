using BadmintonCourtManagement.Application.Interface;
using BadmintonCourtManagement.Application.Service;
using BadmintonCourtManagement.Application.UseCase;
using BadmintonCourtManagement.Application.Utils;
using BadmintonCourtManagement.Domain.Interface;
using BadmintonCourtManagement.Infrastructure.Data;
using BadmintonCourtManagement.Infrastructure.Repository;
using BadmintonCourtManagement.Infrastructure.Testing;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICustomerService, CustomerService>();
//builder.Services.AddScoped<ApplicationDbContext>();
builder.Services.AddScoped<CustomerUseCase>();
builder.Services.AddScoped<ICustomerRepo, CustomerRepo>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<BookingUseCase>();
builder.Services.AddScoped<BookingValidation>();
builder.Services.AddScoped<ICourtService, CourtService>();
builder.Services.AddScoped<CourtUseCase>();
builder.Services.AddScoped<ICourtRepo, CourtRepo>();




// Fix for CS0118: Correctly call AddDbContext with a lambda to configure the options
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var connetionString = builder.Configuration.GetConnectionString("DefaultConnection"); //read connection string from appsettings.json
    options.UseSqlServer(connetionString); //thao tác với sql server
    //options.UseInMemoryDatabase("BadmintonDatabase"); // Use InMemory database for testing purposes
});
    

var app = builder.Build();

//SeedData.Initialize(app.Services); // Seed data into the database

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
