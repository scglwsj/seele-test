using ConsighmentService.Clients;
using ConsighmentService.Repositories;
using ConsighmentService.Services;
using ConsighmentService.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient();
builder.Services.AddMvcCore().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
});

builder.Services.AddDbContext<PaymentContext>(options =>
{
    var sqlConnectionString = builder.Configuration.GetConnectionString("Default");
    options.UseNpgsql(sqlConnectionString);
});

builder.Services.AddScoped<ConsighmentBussinessService>();
builder.Services.AddScoped<CommissionService>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<ITransferClient, TransferClient>();

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
