using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Serilog;
using Serilog.Events;
using WorkerService_Upp1.Models;

namespace WorkerService_Upp1
{
    public class Program
    {

        private static Random rnd = new Random();

        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            .Enrich.FromLogContext()
            .WriteTo.File(@"D:\workerservice\log\LogFile.txt")
            .CreateLogger();

            try
            {
                Log.Information("Starting WorkerService....");
                CreateHostBuilder(args).Build().Run();
                return;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "WorkerService terminated unexpectedly ... Error : { ex.Message}");
                return;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
                
            
                
            


         public enum Level
        {
            Low,
            Normal,
            Hight
        }

        public static int CheckTemperature()
        {

            var temperature = result;
            var _templevel;

            switch (temperature)  //  kan jämföra olika nivå
            {
                case var t when t < 5:
                    _templevel = Level.Low;
                    break;

                case var t when t > 30:
                    _templevel = Level.Hight;
                    break;

                default:
                    _templevel = Level.Normal;
                    break;
            }
            if(_templevel)
            {
                _templevel = Level.Low;
                Console.WriteLine("Temperature is too low . Check your plants!!!");
            }
            
           
        }

        public static async Task<OkObjectResult> Run()
        {


               var result = await Task.Run(() =>{                   
                   var temperature = ????;        
                   
                   return JsonConvert.SerializeObject(new TemperatureModel()
                   {
                       Temperature = ?????
                   }); 
               });
                return new OkObjectResult(result);
        }


        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
        
                .UseSerilog()
                .UseWindowsService()

                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                });


    }
}
