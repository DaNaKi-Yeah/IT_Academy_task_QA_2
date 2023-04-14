using Microsoft.EntityFrameworkCore;
using Recorder.BLL.ApiIntrefaces;
using Recorder.BLL.ApiServices;
using Recorder.BLL.Helpers;
using Recorder.DAL.DataBase.SQL;
using Recorder.DAL.Repositories.Implementations;
using Recorder.DAL.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connection = builder.Configuration.GetConnectionString("ConnectionString");

builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(connection));
builder.Services.AddScoped(typeof(IDbRepository<>), typeof(DbRepository<>));
builder.Services.AddAutoMapper(config => config.AddProfile<MapProfiler>());
builder.Services.AddTransient<IOrderService, OrderService>();


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
