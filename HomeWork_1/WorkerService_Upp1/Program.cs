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

        static void CheckTemperature()
        {

            var temperature = result;  // ??? påbyggnad på result från  async Task<OkObjectResult> 
            var _templevel= Level ("Hight", "Low", "Normal" )  ;

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

         /* jag tror jag vill ha result från _url som ska ge mig nån svar
          * men jag förstå inte hur jag ska hämta det från Worker
          * eller det hämtas automatisk till class Temperature model om jag gör nånting ,
          * vad är det nånting  */
        { 




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
