using System;
using System.Collections.Generic;

public class WeatherStation
{
    private List<IDisplayUnit> _displayUnits = new List<IDisplayUnit>();
    private float _temperature;
    private float _humidity;

    public void AddDisplayUnit(IDisplayUnit displayUnit)
    {
        _displayUnits.Add(displayUnit);
    }

    public void RemoveDisplayUnit(IDisplayUnit displayUnit)
    {
        _displayUnits.Remove(displayUnit);
    }

    public void SetWeatherData(float temperature, float humidity)
    {
        _temperature = temperature;
        _humidity = humidity;
        NotifyDisplayUnits();
    }

    private void NotifyDisplayUnits()
    {
        foreach (var displayUnit in _displayUnits)
        {
            displayUnit.Update(_temperature, _humidity);
        }
    }
}

public interface IDisplayUnit
{
    void Update(float temperature, float humidity);
}

public class SmartphoneDisplay : IDisplayUnit
{
    public void Update(float temperature, float humidity)
    {
        Console.WriteLine($"Smartphone Display - Temperature: {temperature}°C, Humidity: {humidity}%");
    }
}

public class DigitalScreenDisplay : IDisplayUnit
{
    public void Update(float temperature, float humidity)
    {
        Console.WriteLine($"Digital Screen - Temperature: {temperature}°C, Humidity: {humidity}%");
    }
}

public class WebDashboardDisplay : IDisplayUnit
{
    public void Update(float temperature, float humidity)
    {
        Console.WriteLine($"Web Dashboard - Temperature: {temperature}°C, Humidity: {humidity}%");
    }
}

