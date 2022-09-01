using CleanArchitecture.SharedLibrary.Time.Exceptions;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.SharedLibrary.Time.Extensions
{
    public static class DateTimeZoneExtensions
    {

        public static DateTimeZone GetValidTimeZone(this string timezoneId)
        {
            if (string.IsNullOrWhiteSpace(timezoneId))
            {
                throw new ArgumentNullException(nameof(timezoneId));
            }

            var timezone = DateTimeZoneProviders.Tzdb.GetZoneOrNull(timezoneId);

            if (timezone is null)
            {
                throw new InvalidTimezoneException(timezoneId: timezoneId);
            }

            return timezone;
        }
    }
}
