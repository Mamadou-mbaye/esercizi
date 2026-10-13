namespace OrdineManagerApi.Models;

public class OrdineModel
{
    public int Id { get; set; }
    public   string Cliente { get; set; } = string.Empty;
    public DateTime DataOrdine { get; set; }
    public  List<Articolo> Articoli { get; set; } = new ();
    public decimal Totale { get ; set; }
    
}
