using ShipmentTracker.Models;

namespace ShipmentTracker.DataAccess;

public interface IShipmentDataAccess
{
    void Save(ShipmentModel shipment);
    List<ShipmentModel> GetShipments();
}
public class ShipmentDataAccess : IShipmentDataAccess
{
    private readonly List<ShipmentModel> ShipmentRepository = [];
    public void Save(ShipmentModel shipment)
    {
        var record = ShipmentRepository.FirstOrDefault(s => s.ID == shipment.ID);
        if (record != null)
        {
            var index = ShipmentRepository.IndexOf(record);
            ShipmentRepository[index] = shipment;
        }
        else ShipmentRepository.Add(shipment);
    }
    public List<ShipmentModel> GetShipments() => ShipmentRepository;

}       