using CleanArchitecture.SharedLibrary.Common.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.SharedLibrary.Common.Helpers
{
    public class PaginatedListHelper<T>
    {
        public static async Task<PaginatedList<T>> Create(IQueryable<T> source, int pageNumber, int pageSize)
        {
            int count = 0;
            List<T> items= new List<T>();
            var task = Task.Run(() =>
            {
               count = source.Count();
               items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            });

            await task;

            return new PaginatedList<T>(items, count, pageNumber, pageSize);
        }
    }
}
