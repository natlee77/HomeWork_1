using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace WorkerService_Upp1
{
    public class Worker : BackgroundService
    {
        public readonly ILogger<Worker> _logger;
        private static Random rnd = new Random();


        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }


        public override Task StartAsync(CancellationToken cancellationToken)
        {                       
            _logger.LogInformation("THE SERVICE HAS BEEN STARTAD.");
            return base.StartAsync(cancellationToken);
        }


        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("THE SERVICE HAS BEEN STOPPAD.");
            return base.StopAsync(cancellationToken);
        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {           
            while (!stoppingToken.IsCancellationRequested)
            {
                int random_t = rnd.Next(-10, 35);
                try
                {   
                    if (random_t <= 5 )
                        _logger.LogInformation($"The temperature är { random_t}  too low . Ckeck your plants in the garden. ");

                    else if ( random_t >= 25)
                        _logger.LogInformation($"The temperature är { random_t}  too hight . Watter your plants in the garden.  ");
                    
                    else
                        _logger.LogInformation($"The temperature är { random_t}  C .   ");
                }

                catch (Exception ex)
                {
                    _logger.LogInformation($"Failed . {ex.Message}");
                }



                await Task.Delay(60000, stoppingToken);

            }
        }
    }                
}

