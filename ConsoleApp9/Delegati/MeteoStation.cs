using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DotNet.Delegati

    // Design pattern Observer;
{
    public class MeteoStation
    {
        double temperature;
        double pressure;
        double humidity;
        Random dice;
        List<Display> displays;

        //ForecastDisplay fc = new ForecastDisplay();                       // METODO 1
        //AverageConditionDisplay ad = new AverageConditionDisplay();

        public MeteoStation()
        {
            displays = new List<Display>();                                 // METODO 2
            dice = new Random();
            Start();
        }

        public void AddDisplay(Display newDisplay)
        {
            displays.Add(newDisplay);         
        }
        
        public void RemoveDisplay(Display oldDisplay)
        {
            displays.Remove(oldDisplay);
        }

        public void Start()
        {
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(dice.Next(1, 6) * 1000);     // Per mille perché Sleep utilizza i millisecondi;
                temperature = dice.NextDouble() * 50;     // NextDouble prende un numero double da 0 a 1;
                pressure = dice.NextDouble() * 50;
                humidity = dice.NextDouble() * 50;

                Console.WriteLine($"T: {temperature}, P: {pressure}, H: {humidity}");

                foreach(var display in displays)
                {
                    display.Update(temperature, pressure, humidity);
                }

                //ad.Update(temperature, pressure, humidity);
                //fc.Update(temperature, pressure, humidity);
            }
        }
    }
}
