using CleanArchitecture.SharedLibrary.Time.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.SharedLibrary.Common.Extensions
{
    public static class StringExtensions
    {

        /// <summary>
        /// Validates that string is a DateTime with a Kind of UTC
        /// </summary>
        /// <param name="dateTime"></param>
        /// <exception cref="DateTimeKindIsNotUtcException"></exception>
        public static void ValidateDateTimeInUtc(this DateTime dateTime)
        {
            if (dateTime.Kind is not DateTimeKind.Utc)
            {
                throw new DateTimeKindIsNotUtcException($"Invalid Datetime Kind");
            }
        }
    }
}
