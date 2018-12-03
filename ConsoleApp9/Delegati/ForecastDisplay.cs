using System;
using System.Collections.Generic;
using System.Text;

namespace DotNet.Delegati
{
    class ForecastDisplay : Display
    {
        const double WEATHER_DISCRIMINATOR = 80;

        public void Update(double temperature, double pressure, double humidity)
        {
            if((temperature + pressure + humidity) > WEATHER_DISCRIMINATOR)
            {
                Console.WriteLine("Tutti al mare!");
            }
            else
            {
                Console.WriteLine("Mai una gioia!");
            }
        }
    }
}
