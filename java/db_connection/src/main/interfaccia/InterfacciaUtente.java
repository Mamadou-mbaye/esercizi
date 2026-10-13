package main.interfaccia;

import java.awt.BorderLayout;
import javax.swing.*;
import javax.swing.table.DefaultTableModel;

@SuppressWarnings("serial")
public class InterfacciaUtente extends JFrame {
	JFrame frame;
	JPanel jPanel;
	JLabel label;
	JTable table;
	JPanel panel;
	JTextArea textArea;
	JButton button;	
	public void Interfaccia() {
		frame = new JFrame("Nuova finestra");
		frame.setSize(900, 600);
		frame.setVisible(true);
		frame.setLayout(new BorderLayout());
		frame.setDefaultCloseOperation(JFrame.DISPOSE_ON_CLOSE);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
	}
	public void AddComponent(String[][] data,String[] columnNames) {
		_AddComponent(data, columnNames);
	}
	private void _AddComponent(String[][] data,String[] columnNames) {
		CreateLabel();
		CreatePanel(true);
		CreateTable(data, columnNames);
		
		frame.setVisible(true);
	}

	private void CreateLabel() {
		label = new JLabel("Geeks Premier League 2023");
		label.setVisible(true);
		frame.add(label, BorderLayout.NORTH);
	}

	private void CreateTable(String[][] data, String[] columnNames) {
		// Create table model and table
		DefaultTableModel model = new DefaultTableModel(data, columnNames);
		JTable table = new JTable(model);
		// Add table to scroll pane
		JScrollPane scrollPane = new JScrollPane(table);
		 // Main panel with vertical layout to stack components
        JPanel mainPanel = new JPanel();
        mainPanel.setLayout(new BoxLayout(mainPanel, BoxLayout.Y_AXIS));
        // Add the custom panel and the scrollPane
        mainPanel.add(panel);
        mainPanel.add(scrollPane);

        frame.add(mainPanel, BorderLayout.CENTER);
	}
	private void CreatePanel(boolean visible) {
		panel = new JPanel();
        panel.setVisible(visible);			
        label = new JLabel("Dentro panel");		
        panel.add(label);
        textArea = new JTextArea(1,10);	//height , width	
        panel.add(textArea);	
        button = new JButton("Click");
        panel.add(button);
		frame.add(panel, BorderLayout.CENTER);;
	}
}
