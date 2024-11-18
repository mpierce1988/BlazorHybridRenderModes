namespace WebAppRenderModes.Shared.Utilities;

public static class WeatherCodeUtility
{
    private static readonly Dictionary<WeatherEnum, string> WeatherToIconMap = new Dictionary<WeatherEnum, string>
    {
        { WeatherEnum.CLearSky, "wi-day-sunny" },
        { WeatherEnum.MainlyClear, "wi-day-sunny-overcast" },
        { WeatherEnum.PartlyCloudy, "wi-day-cloudy" },
        { WeatherEnum.Overcast, "wi-cloudy" },
        { WeatherEnum.Fog, "wi-fog" },
        { WeatherEnum.DepositingRimeFog, "wi-fog" }, // Similar icon as Fog
        { WeatherEnum.LightDrizzle, "wi-sprinkle" },
        { WeatherEnum.ModerateDrizzle, "wi-sprinkle" },
        { WeatherEnum.HeavyDrizzle, "wi-rain" },
        { WeatherEnum.LightFreezingDrizzle, "wi-sleet" },
        { WeatherEnum.DenseFreezingDrizzle, "wi-sleet" },
        { WeatherEnum.SlightRain, "wi-showers" },
        { WeatherEnum.ModerateRain, "wi-rain" },
        { WeatherEnum.HeavyRain, "wi-heavy-rain" },
        { WeatherEnum.LightFreezingRain, "wi-sleet" },
        { WeatherEnum.HeavyFreezingRain, "wi-sleet" },
        { WeatherEnum.LightSnowFall, "wi-snow" },
        { WeatherEnum.ModerateSnowFall, "wi-snow" },
        { WeatherEnum.HeavySnowFall, "wi-snow" },
        { WeatherEnum.SnowGrains, "wi-snow" }, // No specific icon, using snow
        { WeatherEnum.SlightRainShowers, "wi-showers" },
        { WeatherEnum.ModerateRainShowers, "wi-rain" },
        { WeatherEnum.ViolentRainShowers, "wi-thunderstorm" },
        { WeatherEnum.SlightSnowShowers, "wi-snow" },
        { WeatherEnum.HeavySnowShowers, "wi-snow" },
        { WeatherEnum.Thunderstorm, "wi-thunderstorm" },
        { WeatherEnum.SlightThunderstormWithHail, "wi-thunderstorm" },
        { WeatherEnum.HeavyThunderstormWithHail, "wi-thunderstorm" }
    };

    private static readonly Dictionary<WeatherEnum, string> WeatherToDescriptionMap =
        new Dictionary<WeatherEnum, string>
        {
            { WeatherEnum.CLearSky, "Clear Sky" },
            { WeatherEnum.MainlyClear, "Mainly Clear" },
            { WeatherEnum.PartlyCloudy, "Partly Cloudy" },
            { WeatherEnum.Overcast, "Overcast" },
            { WeatherEnum.Fog, "Fog" },
            { WeatherEnum.DepositingRimeFog, "Depositing Rime Fog" },
            { WeatherEnum.LightDrizzle, "Light Drizzle" },
            { WeatherEnum.ModerateDrizzle, "Moderate Drizzle" },
            { WeatherEnum.HeavyDrizzle, "Heavy Drizzle" },
            { WeatherEnum.LightFreezingDrizzle, "Light Freezing Drizzle" },
            { WeatherEnum.DenseFreezingDrizzle, "Dense Freezing Drizzle" },
            { WeatherEnum.SlightRain, "Slight Rain" },
            { WeatherEnum.ModerateRain, "Moderate Rain" },
            { WeatherEnum.HeavyRain, "Heavy Rain" },
            { WeatherEnum.LightFreezingRain, "Light Freezing Rain" },
            { WeatherEnum.HeavyFreezingRain, "Heavy Freezing Rain" },
            { WeatherEnum.LightSnowFall, "Light Snowfall" },
            { WeatherEnum.ModerateSnowFall, "Moderate Snowfall" },
            { WeatherEnum.HeavySnowFall, "Heavy Snowfall" },
            { WeatherEnum.SnowGrains, "Snow Grains" },
            { WeatherEnum.SlightRainShowers, "Slight Rain Showers" },
            { WeatherEnum.ModerateRainShowers, "Moderate Rain Showers" },
            { WeatherEnum.ViolentRainShowers, "Violent Rain Showers" },
            { WeatherEnum.SlightSnowShowers, "Slight Snow Showers" },
            { WeatherEnum.HeavySnowShowers, "Heavy Snow Showers" },
            { WeatherEnum.Thunderstorm, "Thunderstorm" },
            { WeatherEnum.SlightThunderstormWithHail, "Slight Thunderstorm with Hail" },
            { WeatherEnum.HeavyThunderstormWithHail, "Heavy Thunderstorm with Hail" }
        };

    public static string GetIconClass(WeatherEnum weather)
    {
        if (WeatherToIconMap.TryGetValue(weather, out string? iconClass))
        {
            return iconClass;
        }

        // return default if not found
        return "wi-na";
    }

    public static string GetIconClass(int weatherCode)
    {
        return GetIconClass(GetWeatherEnum(weatherCode));
    }

    public static WeatherEnum GetWeatherEnum(int weatherCode)
    {
        // Try to parse the int as a Weather enum
        if (Enum.IsDefined(typeof(WeatherEnum), weatherCode))
        {
            return (WeatherEnum)weatherCode;
        }

        // If the int is not a valid Weather enum, return the default value
        return WeatherEnum.CLearSky;
    }

    public static string GetDescription(WeatherEnum weather)
    {
        return WeatherToDescriptionMap.GetValueOrDefault(weather, "Unknown");
    }

    public static string GetDescription(int weatherCode)
    {
        return GetDescription(GetWeatherEnum(weatherCode));
    }

    public enum WeatherEnum
    {
        CLearSky = 0,
        MainlyClear = 1,
        PartlyCloudy = 2,
        Overcast = 3,
        Fog = 45,
        DepositingRimeFog = 48,
        LightDrizzle = 51,
        ModerateDrizzle = 53,
        HeavyDrizzle = 55,
        LightFreezingDrizzle = 56,
        DenseFreezingDrizzle = 57,
        SlightRain = 61,
        ModerateRain = 63,
        HeavyRain = 65,
        LightFreezingRain = 66,
        HeavyFreezingRain = 67,
        LightSnowFall = 71,
        ModerateSnowFall = 73,
        HeavySnowFall = 75,
        SnowGrains = 77,
        SlightRainShowers = 80,
        ModerateRainShowers = 81,
        ViolentRainShowers = 82,
        SlightSnowShowers = 85,
        HeavySnowShowers = 86,
        Thunderstorm = 95,
        SlightThunderstormWithHail = 96,
        HeavyThunderstormWithHail = 99
    }
}