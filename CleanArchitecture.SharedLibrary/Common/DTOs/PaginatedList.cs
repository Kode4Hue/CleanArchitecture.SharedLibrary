using System;
using System.Collections.Generic;

namespace CleanArchitecture.SharedLibrary.Common.DTOs
{
    public class PaginatedList<T>
    {
        public List<T> Items { get; set; }
        public int CurrentPageNumber { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public int ItemsPerPage { get; set; }

        public PaginatedList(List<T> items, int count, int currentPageNumber, int itemsPerPage)
        {
            CurrentPageNumber = currentPageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)itemsPerPage);
            TotalCount = count;
            Items = items;
            ItemsPerPage = itemsPerPage;
        }
    }
}
