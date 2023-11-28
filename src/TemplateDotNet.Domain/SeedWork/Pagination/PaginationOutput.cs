namespace TemplateDotNet.Application.Common.Pagination;
public class PaginationOutput<T>
{
    public int Total { get; private set; }
    public List<T> Data { get; private set; }

    public PaginationOutput(
        int total,
        List<T> data
    )
    {
        Total = total;
        Data = data;
    }

    public static PaginationOutput<T> FromOutput(int total, List<T> data) 
        => new(total, data);
}
