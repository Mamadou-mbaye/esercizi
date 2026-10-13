namespace OrdineManagerApi.Models;

public class Articolo
{
    public int Id { get; set; }
    public   string Descrizione { get; set; } = string.Empty;
    public int Quantita { get; set; }
    public decimal PrezzoUnita { get; set; }
    // public decimal Totale { get => Quantita * PrezzoUnita; private set; }
    public decimal Totale   => Quantita * PrezzoUnita; 
    }
