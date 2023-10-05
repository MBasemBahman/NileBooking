namespace Services
{
    public class Pagination<T> where T : class
    {
        public Pagination(int pageNumber, int pageSize, IReadOnlyList<T> data, int count)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            Data = data;
            Count = count;
        }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public IReadOnlyList<T> Data { get; set; }
        public int Count { get; set; }
    }
}
