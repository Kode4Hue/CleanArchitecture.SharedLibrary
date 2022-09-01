using CleanArchitecture.SharedLibrary.Time.Services;
using NodaTime;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.SharedLibrary.Time.Extensions
{
    public static class TimeContainerExtensions
    {

        public static IContainerRegistry RegisterSystemClock(this IContainerRegistry container, string timezoneId)
        {
            var systemClockService = new SystemClockService(SystemClock.Instance, timezoneId);
            container.RegisterInstance<IClockService>(systemClockService);
            return container;
        }
    }
}
