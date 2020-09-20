using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WorkerService_Upp1
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private  readonly string _url = "https://api.openweathermap.org/data/2.5/onecall?lat=59.23797&lon=14.43077&exclude=current&appid=594a02d31f7827d13d00eb499ee71ef4";

        private HttpClient _client;
        private HttpResponseMessage _result;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
            
        }


        public override Task StartAsync(CancellationToken cancellationToken)
        {
            
            _client = new HttpClient();
            _logger.LogInformation("THE SERVICE HAS BEEN STARTAD.");
            return base.StartAsync(cancellationToken);
        }       
        
        
        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _client.Dispose();

            _logger.LogInformation("THE SERVICE HAS BEEN STOPPAD.");
            return base.StopAsync(cancellationToken);
        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    _result = await _client.GetAsync(_url);

                    if (_result.IsSuccessStatusCode)
                        _logger.LogInformation($"The website { _url} is up. StatusCode={_result.StatusCode} ");

                    else
                        _logger.LogInformation($"The website { _url} is down. StatusCode={_result.StatusCode} ");
                }
                
                catch(Exception ex)
                {
                    _logger.LogInformation($"Failed . THE WEBSITE ({_url}) - {ex.Message}"); 
                }
                

                _logger.LogInformation($"The weather { _url} is {_result.Content}");
                _logger.LogInformation("DATE AND TIME: {time}", DateTimeOffset.Now);


                await Task.Delay(60000, stoppingToken);
            }
        }
    }
}