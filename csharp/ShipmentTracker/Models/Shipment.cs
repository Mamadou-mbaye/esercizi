namespace ShipmentTracker.Models;

public class ShipmentModel
{
    public int ID { set; get; }
    public ShipmentTipoModel ShipmentTipo { set; get; } = new ();
    public double Peso { set; get; } //Peso in KG
    public string Destinazione { set; get; } = string.Empty;
    public decimal Costo => ShipmentTipo.Costo * (decimal)Peso;
    //Un programma che, data una spedizione con peso e destinazione, calcoli il costo e simuli la consegna.   
}

public class ShipmentTipoModel
{
    public int ID { set; get; }
    public string  Descrizione { set; get; } = string.Empty;
    public decimal Costo { set; get; } // costo al KG
}