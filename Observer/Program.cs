using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create subject (weather station)
            WeatherStation station = new WeatherStation();

            // Create observers (display units)
            SmartphoneDisplay smartphone = new SmartphoneDisplay();
            DigitalScreenDisplay screen = new DigitalScreenDisplay();
            WebDashboardDisplay dashboard = new WebDashboardDisplay();

            // Add observers to the weather station
            station.AddDisplayUnit(smartphone);
            station.AddDisplayUnit(screen);

            // Update weather data
            station.SetWeatherData(25.5f, 65f); // All observers are notified

            // Add another observer
            station.AddDisplayUnit(dashboard);

            // Update weather data again
            station.SetWeatherData(30.2f, 70f);

            // Remove an observer
            station.RemoveDisplayUnit(screen);

            // Update weather data a third time
            station.SetWeatherData(22.8f, 60f);
        }
    }
}
