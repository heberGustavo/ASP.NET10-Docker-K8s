using ASP.NET10_Docker_K8s.Service;
using ASP.NET10_Docker_K8s.Service.Implementation;
using ASP.NET10_Docker_K8s.Service.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSingleton<MathService>(); // Apenas uma instância para toda a aplicação
builder.Services.AddScoped<IPersonServices, PersonServices>(); // Uma instância por request

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
