using Serilog;

namespace ASP.NET10_Docker_K8s.Configurations
{
    public static class LoggingConfig
    {
        /// <summary>
        /// Necessario configurar Program.cs e appsettings.json
        /// </summary>
        /// <param name="builder"></param>
        public static void AddSerilogLogging(this WebApplicationBuilder builder)
        {
            try
            {
                Log.Logger = new LoggerConfiguration()
                    .ReadFrom.Configuration(builder.Configuration)
                    .Enrich.FromLogContext()
                    .WriteTo.Console()
                    .WriteTo.Debug()
                    .CreateLogger();

                builder.Host.UseSerilog();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
