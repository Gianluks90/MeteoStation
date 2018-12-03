using DotNet.Delegati;
using System;

namespace DotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            MeteoStationDelegate m = new MeteoStationDelegate();

            var d1 = new ForecastDisplay();
            var d2 = new AverageConditionDisplay();

            m.AddDisplay(d1.Update);        // Non si evoca il metodo Update ma l'indirizzo del metodo delegato, per questo non si usano le due parentesi;
            m.AddDisplay(d2.Update);

            m.Start();
        }
    }
}
