using Microsoft.EntityFrameworkCore;
using SmartSchool_WebApi.Data;

using Microsoft.Extensions.Configuration;

 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
builder.Services.AddControllers()
//Ignore o loop infinito
   .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling =
Newtonsoft.Json.ReferenceLoopHandling.Ignore);



//AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = 
                       // Newtonsoft.Json.ReferenceLoopHandling.Ignore);


// builder.Services.AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = 
                        // Newtonsoft.Json.ReferenceLoopHandling.Ignore);
//builder.Services
// regista o servico coom o tempo de vida,um solicitação
builder.Services.AddScoped<IRepository,Repository>();
//.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
//builder.Services.AddScoped(typeof(c),typeof(Repository));
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
//app.UseCors(x=>x.AllowAnyOrigin.All);
   app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
   app.UseAuthorization();

app.MapControllers();

app.Run();
