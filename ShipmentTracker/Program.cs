// See https://aka.ms/new-console-template for more information

using ShipmentTracker.Factories;
using ShipmentTracker.Services;
using ShipmentTracker.DataAccess;
using ShipmentTracker.Models;
using ShipmentTracker.Strategies;

Console.WriteLine("Hello, World!");

IShipmentDataAccess shipmentDataAccess = new ShipmentDataAccess();


ShipmentService shipmentService = new(shipmentDataAccess);


shipmentService.SaveShipment(
    new()
    {
        ID = 1,
        Peso = 10,//Peso in KG
        Destinazione = "Milano",
        ShipmentTipo = ShipmentFactory.StandardShipment(),
    }
);
shipmentService.SaveShipment(
    new()
    {
        ID = 2,
        Peso = 23,//Peso in KG
        Destinazione = "Bergamo",
        ShipmentTipo = ShipmentFactory.EspressoShipment(),
    }
);
shipmentService.SaveShipment(
    new()
    {
        ID = 3,
        Peso = 7,//Peso in KG
        Destinazione = "Brescia", //dove si trova il nostro deposito
        ShipmentTipo = ShipmentFactory.RitiroShipment(),
    }
);

List<ShipmentModel> shipments = shipmentService.GetShipments();
if (shipments.Count == 0) Console.WriteLine("Nessuna consegna");
else
{
    foreach (ShipmentModel shipment in shipments)
    {
        Console.WriteLine($"Tipo di consegna: {shipment.ShipmentTipo.Descrizione}");
        Console.WriteLine($"Costo di consegna al KG: {shipment.ShipmentTipo.Costo}€");
        Console.WriteLine($"Peso: {shipment.Peso}kg");
        Console.WriteLine($"Destinazione: {shipment.Destinazione}");
        Console.WriteLine($"Costo totale consegna: {shipment.Costo}€");

        ShipmentFactory.CreaStrategy(shipment.ShipmentTipo).SimulaConsegna(shipment);
        Console.WriteLine(new string('-', 60));
    }
    Console.WriteLine("Done!");
}
