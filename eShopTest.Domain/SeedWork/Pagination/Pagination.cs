using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace eShopTest.Domain.SeedWork.Pagination
{
    public class Pagination<T> : List<T> where T : class 
    {
        public Pagination(List<T> items, long total, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(total / (double)pageSize);
            AddRange(items);
        }

        public int TotalPages { get; }
        public int PageIndex { get; }
        public bool HasPreviousPage => (PageIndex > 1);
        public bool HasNextPage => (PageIndex < TotalPages);
    }
}
