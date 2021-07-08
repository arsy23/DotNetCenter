namespace DotNetCenter.DateTime.DependencyResolution
{
    using DotNetCenter.DateTime.Common;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection.Extensions;

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
        public static IServiceCollection TryAddDefaultDateTimeServices(this IServiceCollection services)
        {
            services.TryAddTransient<CompoundableDateTimeNow, CompoundDateTimeNowService>();
            services.TryAddTransient<CompoundableDateTime, CompoundDateTimeService>();
            return services;
        }
    }
}
