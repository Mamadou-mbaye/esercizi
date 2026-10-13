using OrdineManagerApi.Models;

namespace OrdineManagerApi.DataAccess;

public interface IOrdineData
{
    List<OrdineModel> GetAll();
    void Save(OrdineModel _ordine);
    }

public class OrdineData : IOrdineData
{
    private readonly List<OrdineModel> OrdineRepository = [];
    public void Save(OrdineModel _ordine)
    {
        var existing = OrdineRepository.FirstOrDefault(o => o.Id == _ordine.Id);
        if (existing != null)
        {
            int index = OrdineRepository.IndexOf(existing);
            OrdineRepository[index] = _ordine;
        }
        else
        {
            OrdineRepository.Add(_ordine);
        }
        Console.WriteLine("Ordine salvato");
    }
    public List<OrdineModel> GetAll() => OrdineRepository;
}