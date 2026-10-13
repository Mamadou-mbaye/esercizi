using ShipmentTracker.Models;
using ShipmentTracker.DataAccess;

namespace ShipmentTracker.Services;

public class ShipmentService
{

    IShipmentDataAccess _shipmentDataAccess;

    public ShipmentService(IShipmentDataAccess shipmentDataAccess )
    {
        _shipmentDataAccess = shipmentDataAccess;
    }

    public void SaveShipment(ShipmentModel shipment)
    {
        if (shipment == null)
            throw new ArgumentNullException(nameof(shipment));
        if (shipment.ID <= 0)
            throw new ArgumentException("Id non valido");
        if (shipment.Peso <= 0)
            throw new ArgumentException("Peso non valido");
        if (shipment.Destinazione == string.Empty)
            throw new ArgumentException("Destinazione non valido");
        if (shipment.ShipmentTipo == null)
            throw new ArgumentException("Tipo di consegna non indicato");
        if (shipment.ShipmentTipo.ID == 0)
            throw new ArgumentException("ID del tipo di consegna non valido");
        if (shipment.ShipmentTipo.Descrizione == string.Empty)
            throw new ArgumentException("Descrizione del tipo di consegna non valido");
        if (shipment.ShipmentTipo.Costo < 0)
            throw new ArgumentException("Costo del tipo di consegna non valido"); //Il costo potrebbe non esserci in caso si tratta di un ritiro

        _shipmentDataAccess.Save(shipment);
        Console.WriteLine("Consegna salvata");
    }

    public List<ShipmentModel> GetShipments()
    {
        return _shipmentDataAccess.GetShipments();
    }




}