package progetto_frutta;

/**
 * This abstract class represents a generic fruit in our fruit basket program.
 * It defines a private weight variable and provides methods to get and set the
 * weight. Since fruits have weight, this class is declared as abstract.
 * Subclasses like Mela (Apple), Arancia (Orange), and Pesca (Peach) will
 * inherit these functionalities.
 */
public abstract class Frutta {
	/*
	 * Creare una classe astratta Frutta che definisce una variabile incapsulata
	 * peso. Per il nostro programma un oggetto Frutta senza peso non ha
	 * senso.Creare le sue sottoclassi Mela, Pesca, Arancia.
	 */

	/**
	 * Weight of the fruit in kilograms.
	 */
	private double peso;

	/**
	 * Constructor for the Frutta class. Initializes the weight of the fruit.
	 * 
	 * @param peso The weight of the fruit in kilograms.
	 */
	public Frutta(double peso) {
		this.peso = peso;
	}

	/**
	 * Getter method to access the weight of the fruit.
	 * 
	 * @return The weight of the fruit in kilograms.
	 */
	public double getPeso() {
		return peso;
	}

	/**
	 * Setter method to modify the weight of the fruit.
	 * 
	 * @param peso The new weight of the fruit in kilograms.
	 */
	public void setPeso(double peso) {
		this.peso = peso;
	}

}
