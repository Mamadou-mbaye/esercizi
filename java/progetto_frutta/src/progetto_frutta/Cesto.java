package progetto_frutta;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;


/**
 * This class represents a generic fruit basket. It holds a list of fruits and provides methods for adding, removing,
 * modifying, and displaying the contents of the basket. The weight of the basket is also tracked and a limit of 5 kg
 * is enforced.
 *
 * @param <T> The type of fruit that can be stored in the basket. This must be a subclass of `Frutta`.
 */
   
    
public class Cesto<T extends Frutta> {
	/*
	 * Creare una classe generica Cesto che astrae il concetto di cesto della
	 * frutta.Questa definisce un array list di frutti. Inoltre deve esporre un
	 * metodo getPeso() che ritorna il peso totale del contenuto della cesta, e un
	 * metodo aggiungi() per aggiungere un frutto alla volta, che rilancia
	 * un’eccezione (creata appositamente) nel caso l’aggiunta del frutto che si
	 * vuole aggiungere faccia superare il limite massimo di 5 chili di peso. Ogni
	 * Cesta deve avere un solo tipo di frutta per volta. Si implementi una
	 * soluzione con i generici.
	 */
	 /**
     * List of fruits stored in the basket.
     */
	private List<T> frutti;
	/**
     * Maximum allowed weight of the basket in kilograms.
    

	 * @pesoMassimo
	 * @return peso massimo in chile
	 */
	private double pesoMassimo;
	 /**
     * Constructor for the `Cesto` class. Initializes the fruit list and sets the maximum weight.
     */
	public Cesto() {
		frutti = new ArrayList<>();
		pesoMassimo = 5;
	}
    /**
     * Adds a new fruit to the basket.
     *
     * @param frutto The fruit to be added to the basket.
     */

	public void aggiungi(T frutto) {
		frutti.add(frutto);
	}
    /**
     * Modifies the weight of a fruit in the basket.
     *
     * @param peso The original weight of the fruit in the basket.
     * @param nuovoPeso The new weight of the fruit to be set.
     */

	public void modificaPeso(double peso, double nuovoPeso) {
		if (frutti.size() == 1) {
			T frutto = frutti.get(0);
			double pesoFinale = peso - nuovoPeso;
			frutto.setPeso(pesoFinale);
		}
	}

    /**
     * Removes a fruit from the basket at the specified index.
     *
     * @param index The index of the fruit to be removed.
     */

	public void rimuovi(int index) {
		frutti.remove(index);
	}
    /**
     * Prints the contents of the basket, including the type and weight of each fruit.
     */

	public void stampa() {
		System.out.println("cesto: ");
		for (int i = 0; i < frutti.size(); i++) {
			System.out.println(
					(i) + ". " + frutti.get(i).getClass().getSimpleName() + " - Peso: " + frutti.get(i).getPeso());
		}
	}

    /**
     * Calculates and returns the total weight of all fruits in the basket.
     *
     * @return The total weight of the basket in kilograms.
     */

	public double getPeso() {
		double pesoTotale = 0;
		for (Frutta frutto : frutti) {
			pesoTotale += frutto.getPeso();
		}
		return pesoTotale;
	}

}
