using ShipmentTracker.Models;
using ShipmentTracker.Strategies;

namespace ShipmentTracker.Factories;

public class ShipmentFactory
{
    public static ShipmentTipoModel StandardShipment()
    {
        return new()
        {
            ID = 1,
            Descrizione = "standard",
            Costo = 1.50m // costo al KG
        };
    }
    public static ShipmentTipoModel EspressoShipment()
    {
        return new()
        {
            ID = 2,
            Descrizione = "espresso",
            Costo = 2.30m // costo al KG
        };
    }
    public static ShipmentTipoModel RitiroShipment()
    {
        return new()
        {
            ID = 3,
            Descrizione = "ritiro",
            Costo = 0 // costo al KG
        };
    }

    // ShipmentFactory.cs
public static IConsegnaStrategy CreaStrategy(ShipmentTipoModel tipo)
{
    return tipo.ID switch
    {
        1 => new ConsegnaStandard(),
        2 => new ConsegnaEspresso(),
        3 => new RitiroInPunto(),
        _ => throw new ArgumentException($"Tipo sconosciuto: {tipo.ID}")
    };
}
}


