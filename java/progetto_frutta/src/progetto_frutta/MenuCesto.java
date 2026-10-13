package progetto_frutta;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

/**
 * This class defines the main menu for interacting with fruit baskets. It
 * allows users to create new baskets, add fruits to them, and manage the weight
 * of the baskets.
 */
public class MenuCesto {
	/**
	 * Main loop of the menu that presents options to the user and handles their
	 * choices.
	 */
	public static void Menu() throws IOException {

		BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
		boolean found = true;
		while (found) {
			System.out.println("Per il cesto scegliere tra mela, arancia , pesca o (exit) per uscire ");
			String tipo = reader.readLine().trim().toLowerCase();
			/**
			 * Creates a new basket for a specific fruit type and adds fruits to it.
			 *
			 * @param cesto The basket to add fruits to.
			 * @param tipo  The type of fruit for the basket (mela, arancia, pesca).
			 */
			switch (tipo) {
			case "mela":
			case "arancia":
			case "pesca":
				Cesto<?> cesto = new Cesto<>();
				CestoFrutta(cesto, tipo);
				break;
			case "exit":
				System.out.println("Arrivederci!");
				found = false;
				break;
			default:
				System.out.println("Scelta non valida");
				break;

			}
		}
	}

	public static <T extends Frutta> void CestoFrutta(Cesto<T> cesto, String tipo) throws IOException {
		BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
		double peso = Input(reader);
		if (peso > 0) {
			switch (tipo) {
			case "mela":
				cesto.aggiungi((T) new Mela(peso));
				break;
			case "arancia":
				cesto.aggiungi((T) new Arancia(peso));
				break;
			case "pesca":
				cesto.aggiungi((T) new Pesca(peso));
				break;
			default:

			}
		}

		cesto.stampa();
		System.out.println("Peso totale del cesto: " + cesto.getPeso());

		while (cesto.getPeso() > 5) {
			/**
			 * Iterates until the total weight of the basket is less than or equal to 5 kg.
			 * Prompts the user to remove fruit if the weight exceeds the limit.
			 */
			System.out.println("Cesto non puo superare 5 chili \n rimuovere qualche chilo:");
			double nuovoPeso = Input(reader);
			cesto.modificaPeso(peso, nuovoPeso);
			cesto.stampa();

			System.out.println("Peso totale del cesto: " + cesto.getPeso());
		}

	}

	/**
	 * Gets a valid weight input from the user.
	 *
	 * @return The valid weight entered by the user.
	 */
	public static double Input(BufferedReader reader) throws IOException {
		double peso = 0;
		boolean validInput = false;
		/**
		 * Prompts the user to enter a valid weight for a fruit. The method ensures the
		 * input is a non-negative double value and confirms the choice with the user.
		 */
		System.out.println("Inserire un peso valido e per uscire inserire '0'");// Inform the user to enter a valid
																				// weight or 0 to exit

		while (!validInput) {
			System.out.println("Inserire peso frutta:");
			// Prompt the user to enter the fruit's weight
			String input = reader.readLine();

			// Check if the user entered "0" to exit
			if (input.equals("0")) {
				System.out.println("Hai scelto di uscire.");
				return peso;// Return the current weight (0) to indicate exit

			}
			try {
				peso = Double.parseDouble(input);// Convert the input to a double value
				if (peso < 0) { // Check if the weight is negative
					System.out.println("Il peso non può essere negativo. Riprova o inserire '0' per uscire.");
					// Error message for negative weight
				} else {
					System.out.println("Il peso inserito è: " + peso);// Display the entered weight
					System.out.println("Vuoi confermare il peso scelto? (Si/No)"); // Ask for confirmation
					String conferma = reader.readLine().trim().toLowerCase();
					if (conferma.equals("si")) {// Check if the user confirmed the weight
						validInput = true;// Set validInput to true to exit the loop
					} else {
						System.out.println("Inserimento annullato. Riprova."); // Inform the user the input value was
																				// canceled
					}
				}
			} catch (NumberFormatException e) {// Catch invalid input (not a double)
				System.out.println("Input non valido. Riprova.");// Error message for invalid input
			}
		}

		return peso;
	}

}