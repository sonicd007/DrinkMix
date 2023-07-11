using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkMix.BusinessLogic.Utilities
{
    /// <summary>
    /// Represents a paginated list of items of type T, including metadata for pagination.
    /// </summary>
    /// <typeparam name="T">The type of the items in the paginated list.</typeparam>
    public class PagedList<T>
    {
        /// <summary>
        /// Gets or sets the items in the current page.
        /// </summary>
        public List<T> Items { get; set; }

        /// <summary>
        /// Gets or sets the number of the current page.
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// Gets or sets the total number of pages.
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        /// Gets or sets the total number of items across all pages.
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// Gets or sets the number of items per page.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Gets a value indicating whether there is a previous page.
        /// </summary>
        public bool HasPrevious => CurrentPage > 1;

        /// <summary>
        /// Gets a value indicating whether there is a next page.
        /// </summary>
        public bool HasNext => CurrentPage < TotalPages;

        public PagedList()
        {
            Items = new List<T>();
            CurrentPage = 1;
            PageSize = 10;
            TotalCount = 0;
        }

        /// <summary>
        /// Initializes a new instance of the PagedList class.
        /// </summary>
        /// <param name="items">The items in the current page.</param>
        /// <param name="count">The total number of items across all pages.</param>
        /// <param name="pageNumber">The number of the current page.</param>
        /// <param name="pageSize">The number of items per page.</param>
        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            CurrentPage = pageNumber;
            TotalPages = count > 1 ? (int)Math.Ceiling(count / (double)pageSize) : 1;
            PageSize = pageSize;
            TotalCount = count;
            Items = items;
        }
    }
}
