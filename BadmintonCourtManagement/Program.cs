using BadmintonCourtManagement.Application.Service;
using BadmintonCourtManagement.Application.UseCase;
using BadmintonCourtManagement.Data;
using BadmintonCourtManagement.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<ApplicationDbContext>();
builder.Services.AddScoped<CustomerUseCase>();
builder.Services.AddScoped<CustomerRepo>();


// Fix for CS0118: Correctly call AddDbContext with a lambda to configure the options
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var connetionString = builder.Configuration.GetConnectionString("DefaultConnection"); //read connection string from appsettings.json
    options.UseSqlServer(connetionString);
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
