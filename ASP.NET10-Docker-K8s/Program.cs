using ASP.NET10_Docker_K8s.Configurations;
using ASP.NET10_Docker_K8s.Repositories;
using ASP.NET10_Docker_K8s.Repositories.Implementation;
using ASP.NET10_Docker_K8s.Service.Implementation;
using ASP.NET10_Docker_K8s.Service.Interface;

var builder = WebApplication.CreateBuilder(args);

builder.AddSerilogLogging();

builder.Services.AddControllers();
builder.Services.AddDatabaseConfiguration(builder.Configuration);

builder.Services.AddScoped<IPersonServices, PersonServices>(); // Uma instância por request
builder.Services.AddScoped<IPersonRepository, PersonRepository>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
