namespace DotNetCenter.DateTime.DependencyResolution
{
    using DotNetCenter.DateTime.Common;

    using Microsoft.Extensions.DependencyInjection;
    public static class DateTimesDependencyInjection
    {
        public static IServiceCollection AddDefaultDateTimeService(this IServiceCollection services)
        {
            services.AddTransient<CompoundableDateTimeNow, CompoundDateTimeNowService>();
            services.AddTransient<CompoundableDateTime, CompoundDateTimeService>();
            return services;
        }
    }
}
