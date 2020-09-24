using System;
using System.Collections.Generic;
using System.Text;


namespace WorkerService_Upp1.Models
{
    public class TemperatureModel
    {
        public double Temperature { get; set; }

        public DateTime Timestamp { get; set; } //när temp  Datum
                
        public TemperatureModel()
        {

        }

        
        public TemperatureModel(double temperature)
        {
            Temperature = temperature;
            Timestamp = DateTime.Now; 
        }
    }
}
