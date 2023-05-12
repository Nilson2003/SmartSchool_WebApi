using Microsoft.EntityFrameworkCore;
using SmartSchool_WebApi.Data;
 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddDbContext<> 
// builder.Services.AddDbContext<DataContext, MyDbContext>(options =>
    //  options.UseSqlServer(...));
builder.Services.AddDbContext<DataContext>(
    x =>x.UseSqlite(builder.Configuration.GetConnectionString("DefaultConn") )

);


builder.Services.AddSwaggerGen();

// services.AddDbContextPool<DataContext>( /*omitted*/ );
// services.AddHostedService<Worker>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
