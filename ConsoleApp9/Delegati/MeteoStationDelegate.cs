using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DotNet.Delegati
    // Design pattern Observer;
{
    public delegate void Update(double t, double p, double h);      // Intestazione di delegate;

    public class MeteoStationDelegate       // Delegato, puntatore a funzione;
    {
        double temperature;
        double pressure;
        double humidity;
        Random dice;
        Update update;

        public MeteoStationDelegate()
        {

            dice = new Random();
            Start();
        }

        public void AddDisplay(Update newDisplay)
        {
            update += newDisplay;
        }
        
        public void RemoveDisplay(Update newDisplay)
        {
            update -= newDisplay;
        }

        public void Start()
        {
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(dice.Next(1, 6)*1000);     // Per mille perché Sleep utilizza i millisecondi;
                temperature = dice.NextDouble()*50;     // NextDouble prende un numero double da 0 a 1;
                pressure = dice.NextDouble()*50;
                humidity = dice.NextDouble()*50;

                Console.WriteLine($"T: {temperature}, P: {pressure}, H: {humidity}");
                if (update != null)
                {
                    update(temperature, pressure, humidity);
                }
            }
        }
    }
}
