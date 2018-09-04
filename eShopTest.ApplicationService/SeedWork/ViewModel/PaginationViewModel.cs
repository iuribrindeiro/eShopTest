using System;
using System.Collections.Generic;
using System.Text;

namespace eShopTest.ApplicationService.SeedWork.ViewModel
{
    public class PaginationViewModel<T> where T : class 
    {
        public List<T> Items { get; set; }
        public int TotalPages { get; set; }
        public int PageIndex { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }
    }
}
