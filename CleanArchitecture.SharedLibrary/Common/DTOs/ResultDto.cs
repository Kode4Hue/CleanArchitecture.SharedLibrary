using System;
using System.Collections.Generic;
using System.Linq;

namespace CleanArchitecture.SharedLibrary.Common.DTOs
{
    public class ResultDto
    {
        internal ResultDto(bool succeeded, IEnumerable<string> errors)
        {
            Succeeded = succeeded;
            Errors = errors.ToArray();
        }

        public bool Succeeded { get; set; }

        public string[] Errors { get; set; }

        public static ResultDto Success()
        {
            return new ResultDto(true, Array.Empty<string>());
        }

        public static ResultDto Failure(IEnumerable<string> errors)
        {
            return new ResultDto(false, errors);
        }
    }
}
