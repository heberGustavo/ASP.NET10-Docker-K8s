using ASP.NET10_Docker_K8s.Configurations;
using ASP.NET10_Docker_K8s.Service.Implementation;
using ASP.NET10_Docker_K8s.Service.Interface;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDatabaseConfiguration(builder.Configuration);

builder.Services.AddScoped<IPersonServices, PersonServices>(); // Uma instância por request

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
