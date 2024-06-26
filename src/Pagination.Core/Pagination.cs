namespace Pagination.Core;

public class Pagination<T>
{
    private readonly IEnumerable<T> _source;

    public Pagination(IEnumerable<T> source)
    {
        _source = source;
    }

    public static Pagination<T> Return(IEnumerable<T> source)
    {
        return new Pagination<T>(source);
    }

    public Pagination<TResult> Bind<TResult>(Func<IEnumerable<T>, Pagination<TResult>> func)
    {
        return func(_source);
    }

    public PaginatedResult<T> Apply(int pageNumber, int pageSize)
    {
        var skip = (pageNumber - 1) * pageSize;
        var take = pageSize;
        var items = _source.Skip(skip).Take(take).ToList();
        var totalItems = _source.Count();
        var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

        return new PaginatedResult<T>
        (
            PageNumber: pageNumber,
            PageSize: pageSize,
            TotalItems: totalItems,
            TotalPages: totalPages,
            Items: items
        );
    }
}
