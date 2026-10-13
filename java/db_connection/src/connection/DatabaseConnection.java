package connection;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

/*public class DatabaseConnection  {
       private  Connection con = null;
       public  Connection getConnection() throws ClassNotFoundException, SQLException {
   		Class.forName("com.mysql.cj.jdbc.Driver");
   		con = DriverManager.getConnection("jdbc:mysql://localhost:3306/root?autoReconnect=true&useSSL=false", "root",
   				"R4ndomS3cure");
   		System.out.println("Connessione al database riuscita!");
   		return con;
   	}
       public ResultSet excecuteQuery(String query) throws SQLException {
           Statement stmt = con.createStatement(ResultSet.TYPE_SCROLL_INSENSITIVE, ResultSet.CONCUR_READ_ONLY);
           return stmt.executeQuery(query);
       }
} */
public class DatabaseConnection  {
    private Connection con = null;

    public Connection getConnection() throws ClassNotFoundException, SQLException {
        Class.forName("com.mysql.cj.jdbc.Driver");
        con = DriverManager.getConnection("jdbc:mysql://localhost:3306/root?autoReconnect=true&useSSL=false", "root",
                "R4ndomS3cure");
        System.out.println("Connessione al database riuscita!");
        return con;
    }

    public boolean isConnected() {
        return con != null;
    }

    public ResultSet excecuteQuery(String query) throws SQLException {
        if (con == null) throw new SQLException("Connessione non stabilita.");
        Statement stmt = con.createStatement(ResultSet.TYPE_SCROLL_INSENSITIVE, ResultSet.CONCUR_READ_ONLY);
        return stmt.executeQuery(query);
    }
}
