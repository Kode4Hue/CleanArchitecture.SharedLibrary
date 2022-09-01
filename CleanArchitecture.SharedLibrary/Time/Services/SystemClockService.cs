using CleanArchitecture.SharedLibrary.Common.Extensions;
using CleanArchitecture.SharedLibrary.Time.Constants;
using CleanArchitecture.SharedLibrary.Time.Extensions;
using NodaTime;
using NodaTime.Text;
using NodaTime.TimeZones;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.SharedLibrary.Time.Services
{
    public class SystemClockService : IClockService
    {
        private readonly IClock _clock;

        public DateTimeZone TimeZone { get; private set; }

        public LocalDateTime LocalNow => throw new NotImplementedException();

        public SystemClockService(string timezoneId)
            : this(SystemClock.Instance, timezoneId)
        {
        }

        public SystemClockService(IClock clock, string timezoneId)
        {
            if(clock is null)
            {
                throw new ArgumentNullException(nameof(clock));
            }

            if (string.IsNullOrWhiteSpace(timezoneId))
            {
                throw new ArgumentNullException(nameof(timezoneId));
            }

            _clock = clock;
            TimeZone = timezoneId.GetValidTimeZone();
        }

        public Instant ToInstant(LocalDateTime? local)
        {
            if(local is null)
            {
                throw new ArgumentNullException(nameof(local));
            }

            return local.GetValueOrDefault().InZone(TimeZone, Resolvers.LenientResolver).ToInstant();
        }

        public Instant DateTimeUtcToInstant(DateTime? dateTimeUtc)
        {
            if (dateTimeUtc is null)
            {
                throw new ArgumentNullException(nameof(dateTimeUtc));
            }

            dateTimeUtc?.ValidateDateTimeInUtc();

            return Instant.FromDateTimeUtc(dateTimeUtc.GetValueOrDefault());
        }

        public LocalDateTime ToLocal(Instant? instant)
        {
            if (instant is null)
            {
                throw new ArgumentNullException(nameof(instant));
            }

            return instant.GetValueOrDefault().InZone(TimeZone).LocalDateTime;
        }

        public Instant GetCurrentInstantNow()
        {
            return this._clock.GetCurrentInstant();
        }

        public DateTime GetDateTimeNowUtc()
        {
            return this.GetCurrentInstantNow().ToDateTimeUtc();
        }

        public LocalDateTime GetLocalDateTimeNow()
        {
            return GetCurrentInstantNow().InZone(TimeZone).LocalDateTime;
        }

        public bool IsDateInThePast(DateTime dateInUtc)
        {
            dateInUtc.ValidateDateTimeInUtc();
            var localStartDate = LocalDate.FromDateTime(dateInUtc);
            var localCurrentDateNow = GetLocalDateTimeNow().Date;
            return localStartDate < localCurrentDateNow;
        }

        public bool IsDateTimeInThePast(DateTime dateInUtc)
        {
            dateInUtc.ValidateDateTimeInUtc();
            var localStartDate = LocalDateTime.FromDateTime(dateInUtc);
            var localCurrentDateNow = GetLocalDateTimeNow();
            return localStartDate < localCurrentDateNow;
        }

        public string FormatDateTimeUtcAsLocalDateString(DateTime dateTimeUtc, string dateFormat = DateTimeFormats.EmailDateFormat)
        {
            string formattedDateAsString;
            dateTimeUtc.ValidateDateTimeInUtc();

            try
            {
                var instant = DateTimeUtcToInstant(dateTimeUtc);
                var zonedDateTime  = new ZonedDateTime(instant, TimeZone);
                var localDatePatter = LocalDatePattern.CreateWithInvariantCulture(dateFormat);
                formattedDateAsString = localDatePatter.Format(zonedDateTime.Date);
            }
            catch (Exception ex)
            {

                throw;
            }

            return formattedDateAsString;
        }

        public string FormatAnyDateTimeAsLocalDateString(DateTime dateTime, string dateFormat = DateTimeFormats.EmailDateFormat)
        {
            string formattedDateAsString;

            try
            {
                var localDateTime = LocalDateTime.FromDateTime(dateTime);
                var zonedDateTime = localDateTime.InZoneStrictly(TimeZone);
                var localDatePatter = LocalDatePattern.CreateWithInvariantCulture(dateFormat);
                formattedDateAsString = localDatePatter.Format(zonedDateTime.Date);
            }
            catch (Exception ex)
            {
                throw;
            }

            return formattedDateAsString;
        }
    }
}
