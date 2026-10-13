using OrdineManagerApi.Models;
using OrdineManagerApi.DataAccess;

namespace OrdineManagerApi.Services;

public class OrdineService
{
    private readonly IOrdineData _ordineData;
    public OrdineService(IOrdineData ordineData)
    {
        _ordineData = ordineData;
    }
    public void SalvaOrdine(OrdineModel ordine)
    {
        ArgumentNullException.ThrowIfNull(ordine);
        if (ordine.Id < 1)
            throw new InvalidOperationException("Id non valido");
        if (ordine.Articoli.Count == 0)
            throw new ArgumentException("Devi includere almeno un articolo nell'ordine");
        ordine.Totale = ordine.Articoli.Sum(a => a.Totale);
        if (ordine.Totale > 100)
            ordine.Totale *= 0.9m;
        _ordineData.Save(ordine);
    }
    public List<OrdineModel> GetAllOrdine()
    {
        return _ordineData.GetAll();
    }
}