namespace DeloitteProject.Domain.Models
{
    public struct PaginatedData<T>
    {
        /// <summary>
        /// Items returned in result
        /// </summary>
        public IEnumerable<T> Items { get; set; }

        /// <summary>
        /// Total number of items
        /// </summary>
        public int TotalItems { get; set; }

        public PaginatedData(IEnumerable<T> items, int totalItems)
        {
            Items = items;
            TotalItems = totalItems;
        }
    }
}
