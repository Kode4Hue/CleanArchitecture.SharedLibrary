using System;
using System.Collections.Generic;
using System.Linq;

namespace CleanArchitecture.SharedLibrary.Common.DTOs
{
    public class ResultDto<T> where T : class
    {
        internal ResultDto(bool succeeded, IEnumerable<string>? errors = null, T? content = null)
        {
            Succeeded = succeeded;
            Errors = errors?.ToArray();
            Content = content;
        }

        public bool Succeeded { get; set; }

        public string[]? Errors { get; set; }

        public T? Content { get; set; }

        public static ResultDto<T> Success(T? content)
        {
            return new ResultDto<T>(true, null, content);
        }

        public static ResultDto<T> Failure(IEnumerable<string> errors)
        {
            return new ResultDto<T>(false, errors);
        }
    }
}
