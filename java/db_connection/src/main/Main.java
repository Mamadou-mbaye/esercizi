package main;

import java.sql.ResultSet;
import java.sql.ResultSetMetaData;
import java.sql.SQLException;
import connection.DatabaseConnection;
import main.interfaccia.InterfacciaUtente;

public class Main {
	private static DatabaseConnection connection = new DatabaseConnection();
	static InterfacciaUtente interfaccia = new InterfacciaUtente();
	public static void main(String[] args) {
		interfaccia.Interfaccia();
		GetRecords();
	}
	/*private static void GetRecords() {
		 String[][] data ;
		 String[] columnNames;// = { "id_autore", "nome_penna", "pseudonimo" ,"id_persona"};
		 try {
		        connection.getConnection();//;
		        if (!connection.isConnected()) {
		            System.out.println("Impossibile connettersi al database.");
		            return;
		        }
		        String dbTable ="economix.cash_flow";// "esercizioAutori.autori";
		        ResultSet rs = connection.excecuteQuery("SELECT * FROM " + dbTable);
		        ResultSetMetaData rsmd = rs.getMetaData();
		        int columnCount = rsmd.getColumnCount();
		        // Popola columnNames
		        columnNames = new String[columnCount];
		        for (int i = 1; i <= columnCount; i++) {
		            columnNames[i - 1] = rsmd.getColumnName(i);
		        }
		        // Conta il numero di righe nel ResultSet
		        rs.last();
		        int rowCount = rs.getRow();
		        rs.beforeFirst();
		        
		        // Inizializza l'array data
		        data = new String[rowCount][columnCount];
		        
		        int rowIndex = 0;
		        while (rs.next()) {
		            for (int i = 1; i <= columnCount; i++) {
		                data[rowIndex][i - 1] = rs.getString(i);
		            }
		            rowIndex++;
		        }
		        interfaccia.AddComponent(data, columnNames);
		    }
		
		catch (ClassNotFoundException | SQLException e) {
			e.printStackTrace();
		}
	} */
	private static void GetRecords() {
	    String[][] data;
	    String[] columnNames;

	    try {
	        connection.getConnection();
	        
	        if (!connection.isConnected()) {
	            System.out.println("Impossibile connettersi al database.");
	            return;
	        }

	        String dbTable = "economix.cash_flow";
	        ResultSet rs = connection.excecuteQuery("SELECT * FROM " + dbTable);
	        ResultSetMetaData rsmd = rs.getMetaData();
	        int columnCount = rsmd.getColumnCount();

	        columnNames = new String[columnCount];
	        for (int i = 1; i <= columnCount; i++) {
	            columnNames[i - 1] = rsmd.getColumnName(i);
	        }

	        rs.last();
	        int rowCount = rs.getRow();
	        rs.beforeFirst();

	        data = new String[rowCount][columnCount];
	        
	        int rowIndex = 0;
	        while (rs.next()) {
	            for (int i = 1; i <= columnCount; i++) {
	                data[rowIndex][i - 1] = rs.getString(i);
	            }
	            rowIndex++;
	        }
	        
	        interfaccia.AddComponent(data, columnNames);
	    } catch (ClassNotFoundException | SQLException e) {
	        System.out.println("Errore di connessione al database: " + e.getMessage());
	    }
	}

}
