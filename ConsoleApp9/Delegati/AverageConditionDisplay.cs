using System;
using System.Collections.Generic;
using System.Text;

namespace DotNet.Delegati
{
    class AverageConditionDisplay : Display
    {
        Dictionary<String, AverageData> averages = new Dictionary<string, AverageData>();

        public AverageConditionDisplay()
        {
            averages.Add("T", new AverageData());
            averages.Add("P", new AverageData());
            averages.Add("H", new AverageData());
        }

        public void Update(double temperature, double pressure, double humidity)
        {
            averages["T"] = averages["T"].NextAverage(temperature);
            averages["P"] = averages["P"].NextAverage(pressure);
            averages["H"] = averages["H"].NextAverage(humidity);

            Console.WriteLine($"Avg T: {averages["T"].Average}, Avg P: {averages["P"].Average}, Avg H: {averages["H"].Average}");
        }

        private class AverageData
        {
            double average;
            int measures;

            public double Average => average;

            public AverageData NextAverage(double measurement)
            {
                var avg = new AverageData();
                avg.measures = this.measures + 1;
                double newAverage = (this.average * this.measures + measurement) / avg.measures;
                avg.average = newAverage;
                return avg;
            }
        }
    }
}
