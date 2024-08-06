namespace Application.Dtos.PaginationDtos;
public sealed record PaginationResponseDto<T>
{
    public List<T> Items { get; set; } = [];
    public int TotalCount { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public bool IsFirstPage { get; set; }
    public bool IsLastPage { get; set; }
}