// See https://aka.ms/new-console-template for more information
using OrdineManager.Services;
using OrdineManager.DataAccess;
using OrdineManager.Models;

Console.WriteLine("Hello, World!");

IOrdineData ordineData = new OrdineData();
OrdineService ordineService = new(ordineData);

ordineService.SalvaOrdine(new OrdineModel
{
    Id = 1,
    Cliente = "Cliente 1",
    DataOrdine = DateTime.Now,
    Articoli =
    [
        new() { Id = 1, Descrizione = "Scarpe", Quantita = 3, PrezzoUnita = 5 },
        new() { Id = 2, Descrizione = "Acqua", Quantita = 5, PrezzoUnita = 1 },
        new() { Id = 3, Descrizione = "Chiave", Quantita = 2, PrezzoUnita = 3 },
    ]
});

ordineService.SalvaOrdine(new OrdineModel
{
    Id = 2,
    Cliente = "Cliente 2",
    DataOrdine = DateTime.Now,
    Articoli =
    [
        new() { Id = 1, Descrizione = "Penna", Quantita = 1, PrezzoUnita = 1 },
        new() { Id = 2, Descrizione = "Jeans", Quantita = 1, PrezzoUnita = 25 },
        new() { Id = 3, Descrizione = "Foglio", Quantita = 5, PrezzoUnita = 1.50m },
    ]
});
Console.WriteLine();
foreach (var ordine in ordineService.GetAllOrdine())
{
    Console.WriteLine($"Cliente: {ordine.Cliente}");
    Console.WriteLine($"Data: {ordine.DataOrdine}");
    Console.WriteLine($"Totale ordine: {ordine.Totale:C}");
    foreach (var articolo in ordine.Articoli)
    {
        Console.WriteLine($"  {articolo.Descrizione} — {articolo.Quantita} x {articolo.PrezzoUnita:C} = {articolo.Totale:C}");
    }
    Console.WriteLine(new string('-', 60));
}
Console.WriteLine("Done!");
