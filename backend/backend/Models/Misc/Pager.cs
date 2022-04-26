
namespace backend.Models.Misc
{
    public class Pager<T>
    {
        public int CurrentPage { get; set; }
        public List<T> Items { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public Pager(List<T> displayedItems, int count, int currentPage, int pageSize)
        {
            CurrentPage = currentPage;
            TotalCount = count;
            PageSize = pageSize;
            Items = displayedItems;
            TotalPages = (int)Math.Ceiling((double)count / (double)pageSize);
        }
        public bool HasPreviousPage
        {
            get
            {
                return (CurrentPage > 1);
            }
        }
        public bool HasNextPage
        {
            get
            {
                return (CurrentPage < TotalPages);
            }
        }
    }
}
