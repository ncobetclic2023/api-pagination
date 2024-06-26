var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseDeveloperExceptionPage();

app.MapGet("/", () => "Welcome to the API pagination sample!");

var items = Enumerable.Range(1, 100).Select(i => new Item(i, $"Item {i}")).ToList();

app.MapGet("/api/items", () =>
{
    return Results.Ok(items);
});


app.Run();
