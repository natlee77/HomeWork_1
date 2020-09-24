using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WorkerService_Upp1.Models;

namespace AzureFunction
{
    public static class GetTemperature
    {

        private static Random rnd = new Random();


        [FunctionName("GetTemperature")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)

        {
            return new OkObjectResult(await Task.Run(() =>
            {

                return JsonConvert.SerializeObject(new TemperatureModel()
                {
                    Temperature = rnd.Next(20, 30),
                });
            }));
        }
    }    
    
}
