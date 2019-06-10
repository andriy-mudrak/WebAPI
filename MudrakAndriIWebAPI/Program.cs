using DAL;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace MudrakAndriIWebAPI
{
    public class Program
    {
        public static void Main( string [] args )
        {
            var host = CreateWebHostBuilder( args ).Build();

            using ( var scope = host.Services.CreateScope() )
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<MyDBContext>();

                DataGenerator.Initialize( services );
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder( string [] args ) =>
            WebHost.CreateDefaultBuilder( args )
                .UseStartup<Startup>();
    }
}
