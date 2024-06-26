using Pagination.Core;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseDeveloperExceptionPage();

app.MapGet("/", () => "Welcome to the API pagination sample!");

var items = Enumerable.Range(1, 100).Select(i => new Item(i, $"Item {i}")).ToList();

app.MapGet("/api/items", (int pageNumber, int pageSize) =>
{
    var pagination = Pagination<Item>.Return(items);
    var paginatedResult = pagination.Apply(pageNumber, pageSize);
    return Results.Ok(paginatedResult);
});

app.Run();
