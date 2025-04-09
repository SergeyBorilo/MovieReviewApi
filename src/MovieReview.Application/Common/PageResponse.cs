namespace MovieReview.Application.Common;

public class PageResponse<T> where T : class
{
    public int TotalCount { get; init; }
    public int PageNumber { get; init; }
    public int PageSize { get; init; }
    public int Count { get; set; }
    public T Data { get; set; }

    public int TotalPages =>
        PageSize == 0 ? 0 : (int)Math.Ceiling((double)TotalCount / PageSize);

}
