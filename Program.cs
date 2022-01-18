using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var hostUrl = "http://192.168.1.11:5001"; //configuration["hosturl"]; 

            var configuration = new ConfigurationBuilder().AddCommandLine(args).Build();
 

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseUrls(hostUrl)  
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseConfiguration(configuration)
                .Build();

 

            host.Run(); 
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}