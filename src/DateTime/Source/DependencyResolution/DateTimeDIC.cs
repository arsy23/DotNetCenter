namespace DotNetCenter.DateTime.DependencyResolution
{
    using DotNetCenter.DateTime.Common;
    using Microsoft.Extensions.DependencyInjection;
    /// <summary>
    /// DateTime Dependency Injection Container
    /// </summary>
    public static class DateTimeDIC
    {
        public static IServiceCollection AddDefaultDateTimeServices(this IServiceCollection services)
        {
            services.AddTransient<CompoundableDateTimeNow, CompoundDateTimeNowService>();
            services.AddTransient<CompoundableDateTime, CompoundDateTimeService>();
            return services;
        }
    }
}
