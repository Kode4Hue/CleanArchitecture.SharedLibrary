using CleanArchitecture.SharedLibrary.Common.Extensions;
using CleanArchitecture.SharedLibrary.Time.Constants;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.SharedLibrary.Time.Services
{
    public interface IClockService
    {
        DateTimeZone TimeZone { get; }

        Instant GetCurrentInstantNow();
        public DateTime GetDateTimeNowUtc();

        LocalDateTime GetLocalDateTimeNow();

        Instant ToInstant(LocalDateTime? local);

        Instant DateTimeUtcToInstant(DateTime? dateTimeUtc);

        LocalDateTime ToLocal(Instant? instant);

        bool IsDateInThePast(DateTime dateInUtc);

        bool IsDateTimeInThePast(DateTime dateInUtc);

        string FormatDateTimeUtcAsLocalDateString(DateTime dateTimeUtc, string dateFormat = DateTimeFormats.EmailDateFormat);
        string FormatAnyDateTimeAsLocalDateString(DateTime dateTime, string dateFormat = DateTimeFormats.EmailDateFormat);

    }
}
