namespace Application.Dtos.PaginationDtos;
public record PaginationRequestDto
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string? SearchText { get; set; }
}
