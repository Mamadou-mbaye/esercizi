using ShipmentTracker.Models;

namespace ShipmentTracker.Strategies;
public interface IConsegnaStrategy
{
    void SimulaConsegna(ShipmentModel shipment);
}

public class ConsegnaStandard : IConsegnaStrategy
{
    public void SimulaConsegna(ShipmentModel shipment)
        => Console.WriteLine($"[STANDARD] Spedizione verso {shipment.Destinazione} in 3-5 giorni.");
}

public class ConsegnaEspresso : IConsegnaStrategy
{
    public void SimulaConsegna(ShipmentModel shipment)
        => Console.WriteLine($"[ESPRESSO] Spedizione verso {shipment.Destinazione} in 24h.");
}

public class RitiroInPunto : IConsegnaStrategy
{
    public void SimulaConsegna(ShipmentModel shipment)
        => Console.WriteLine($"[RITIRO] Il cliente passa a ritirare a {shipment.Destinazione}.");
}