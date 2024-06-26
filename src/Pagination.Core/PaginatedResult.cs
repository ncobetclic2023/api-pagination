namespace Pagination.Core;

public record PaginatedResult<T>(int PageNumber, int PageSize, int TotalItems, int TotalPages, List<T> Items);
