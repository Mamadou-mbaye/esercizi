package calculator_project;

import java.util.Scanner;

public class Calcolatrice {

	public static void main(String[] args) {
		/* creare un programma che mi permette di fare semplici calcoli matematici */
		//System.out.println("Insert a number");
		try (Scanner scan = new Scanner(System.in)) {
			System.out.println("Insert first number and press 'Enter'");
			double x = scan.nextDouble();
			System.out.println("Insert second number and press 'Enter'");
			double y = scan.nextDouble();
			scan.nextLine();
			System.out.println("indicate operation: + - * / and press 'Enter'");
			String operator = scan.nextLine().trim();
			switch (operator) {
			case "+":
				System.out.print("x + y: => ");
				System.out.println(x + y);
				break;
			case "-":
				System.out.print("x - y: => ");
				System.out.println(x - y);
				break;
			case "*":
				System.out.print("x * y: => ");
				System.out.println(x * y);
				break;
			case "/":
				System.out.print("x / y: => ");
				System.out.println(x / y);
				break;
			default:
				System.out.println("Operator is not valid");
			}
		}

	}

}
