using OrdineManagerApi.DataAccess;
using OrdineManagerApi.Models;
using OrdineManagerApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSingleton<IOrdineData, OrdineData>(); //usato singleton perché non c'è un db reale 
builder.Services.AddScoped<OrdineService>();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapGet("/", () =>
{
    return "Benvenuto, hello";
})
.WithName("Home");

app.MapPost("/Ordine", (OrdineModel ordine, OrdineService ordineService) =>
{
    ordineService.SalvaOrdine(ordine);
    return Results.Ok($"Ordine {ordine.Id} salvato con successo");
});

app.MapGet("/Ordine", (OrdineService ordineService) =>
{
    var ordini = ordineService.GetAllOrdine();
    return Results.Ok(ordini);
});

app.Run();


